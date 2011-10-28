using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class PausedForm : Form
	{
		// ReSharper disable InconsistentNaming
		// native consts are used for click-through
		const int WS_EX_LAYERED = 0x00080000;
		const int WS_EX_TRANSPARENT = 0x0020;
		const int WS_EX_NOACTIVATE = 0x08000000;
		// ReSharper restore InconsistentNaming

		public PausedForm()
		{
			InitializeComponent();

			// immediately create window so we can invoke
			base.CreateHandle();
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

		private void GrowTimerTick(object sender, EventArgs e)
		{
			if (Opacity <= 0)
			{
				growTimer.Stop();
				Hide();
				return;
			}
			Opacity -= 0.05;
			pausedLabel.Font = new Font(pausedLabel.Font.FontFamily, pausedLabel.Font.Size + 10);
		}

		public void Start()
		{
			Action start = () =>
			{
				Opacity = 1;
				Top = 0;
				Left = 0;
				Width = Screen.PrimaryScreen.WorkingArea.Width;
				Height = Screen.PrimaryScreen.WorkingArea.Height;
				pausedLabel.Font = new Font(pausedLabel.Font.FontFamily, 1);
				growTimer.Start();
				Show();
			};

			if (InvokeRequired)
				Invoke(start);
			else
				start();
		}
	}
}
