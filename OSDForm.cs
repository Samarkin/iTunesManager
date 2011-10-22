using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Helpers;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public partial class OSDForm : Form
	{
// ReSharper disable InconsistentNaming
// native consts are used for click-through
		const int WS_EX_LAYERED = 0x00080000;
		const int WS_EX_TRANSPARENT = 0x0020;
		const int WS_EX_NOACTIVATE = 0x08000000;
// ReSharper restore InconsistentNaming

		private double _targetOpacity;
		private bool _isShowing;
		private double _maxOpacity;
		private OSDPosition _osdPosition;

		public OSDForm()
		{
			InitializeComponent();
			Settings.Default.SettingsSaving += SettingsSaving;
			closeTimer.Tick += CloseTimerTick;
			showHideTimer.Tick += ShowHideTimerTick;

			ApplySettings();

			// immediately create window
			base.CreateHandle();
		}

		private void ApplySettings()
		{
			closeTimer.Interval = Settings.Default.OSDDisplayTime;
			var opacity = Settings.Default.OSDOpacity;
			_maxOpacity = Math.Max(Math.Min(opacity, 1), 0);
			// ReSharper disable CompareOfFloatsByEqualityOperator
			// we're not performing arithmetic operations on opacity,
			// so it will not lose its precision
			// but it is okay to rewrite settings anyway
			if (_maxOpacity != opacity)
				Settings.Default.OSDOpacity = _maxOpacity;
			// ReSharper restore CompareOfFloatsByEqualityOperator
			_osdPosition = Settings.Default.OSDPosition;
		}

		private void SettingsSaving(object sender, CancelEventArgs e)
		{
			ApplySettings();
		}

		protected override CreateParams CreateParams
		{
			get
			{
				// enable click-through
				var cp = base.CreateParams;
				cp.ExStyle |= WS_EX_TRANSPARENT | WS_EX_LAYERED | WS_EX_NOACTIVATE;
				return cp;
			}
		}

		private void ShowHideTimerTick(object sender, EventArgs e)
		{
			if (_isShowing)
			{
				Opacity += 0.03;
				if (Opacity >= _targetOpacity)
				{
					showHideTimer.Stop();
					closeTimer.Start();
				}
			}
			else
			{
				Opacity -= 0.05;
				if (Opacity <= _targetOpacity)
				{
					showHideTimer.Stop();
					Hide();
				}
			}
		}

		private void CloseTimerTick(object sender, EventArgs e)
		{
			closeTimer.Stop();
			SmoothHide();
		}

		private void SetWindowPosition()
		{
			var wa = Screen.GetWorkingArea(this);
			if (_osdPosition == OSDPosition.ScreenBottom)
			{
				Top = wa.Height - Height;
				Left = 0;
				Width = wa.Width;
			}
			else if (_osdPosition == OSDPosition.ScreenTop)
			{
				Top = 0;
				Left = 0;
				Width = wa.Width;
			}
		}

		public void SmoothHide()
		{
			_targetOpacity = 0;
			_isShowing = false;
			showHideTimer.Start();
		}

		public void SmoothShow()
		{
			Opacity = 0;
			_targetOpacity = _maxOpacity;
			Show();
			_isShowing = true;
			showHideTimer.Start();
		}

		public void DisplayOSD(string title, int duration, int rating, string artist, string album, string artworkFileName)
		{
			Action displayOSD = () =>
			{
				closeTimer.Stop();
				titleLabel.Text = title;
				durationLabel.Text = string.Format("{0}:{1:00}", duration / 60, duration % 60);
				var sb = new StringBuilder();
				for (int i = 0; i < 100; i += 20)
				{
					sb.Append(i < rating ? '★' : '☆');
				}
				ratingLabel.Text = sb.ToString();
				artistLabel.Text = artist;
				albumLabel.Text = album;
				if (!string.IsNullOrEmpty(artworkFileName))
				{
					artworkPicture.Load(artworkFileName);
				}
				else
				{
					var assembly = Assembly.GetExecutingAssembly();
					var imageStream = assembly.GetManifestResourceStream("WindowsFormsApplication1.artwork.png");
					if (imageStream != null)
					{
						var bitmap = new Bitmap(imageStream);
						artworkPicture.Image = bitmap;
					}
				}
				SetWindowPosition();

				// if already hiding
				if (showHideTimer.Enabled && !_isShowing)
				{
					// then show again!
					_isShowing = true;
					_targetOpacity = _maxOpacity;
				}

				if (!Visible) SmoothShow();
				else closeTimer.Start();
			};

			if (InvokeRequired)
				Invoke(displayOSD);
			else
				displayOSD();
		}
	}
}
