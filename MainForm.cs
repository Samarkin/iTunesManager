using System;
using System.Drawing;
using System.Windows.Forms;
using iTunesLib;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
	public partial class MainForm : Form
	{
		private readonly PlayerControllerService _control;

		public MainForm(PlayerControllerService control)
		{
			if (control == null) return;
			_control = control;
			InitializeComponent();
			Icon = new Icon(GetType(), "Main.ico");
		}

		private void ButtonClick(object sender, EventArgs e)
		{
			_control.PlayPause();
		}

		private void OnTrackChanged(object iTrack)
		{
			try
			{
				var player = _control.Player;
				var current = iTrack as IITTrack ?? player.CurrentTrack;
				if(current == null) return;
				Action changeText = () =>
					{
						Text = String.Format("{0} - {1} ({2} - {3})", current.Artist, current.Name, current.Year,
							 current.Album);
					};
				Invoke(changeText);
				foreach (IITArtwork artwork in current.Artwork)
				{
					string tempfile = null;
					try
					{
						tempfile = Path.GetTempFileName();
						artwork.SaveArtworkToFile(tempfile);
						pictureBox1.Load(tempfile);
					}
					finally
					{
						if(tempfile != null && File.Exists(tempfile))
							File.Delete(tempfile);
					}
				}
			}
			catch (COMException)
			{

			}
		}

		private void MainFormClosing(object sender, FormClosingEventArgs e)
		{
			Hide();
			if(e.CloseReason != CloseReason.ApplicationExitCall)
				e.Cancel = true;
		}

		private void MainFormVisibleChanged(object sender, EventArgs e)
		{
			var player = _control.Player;
			if (Visible)
			{
				player.OnPlayerPlayEvent += OnTrackChanged;
				player.OnPlayerPlayingTrackChangedEvent += OnTrackChanged;
				OnTrackChanged(null);
			}
			else
			{
				player.OnPlayerPlayEvent -= OnTrackChanged;
				player.OnPlayerPlayingTrackChangedEvent -= OnTrackChanged;
			}
		}
	}
}
