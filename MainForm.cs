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
		private readonly iTunesAppClass _player;

		public MainForm(iTunesAppClass player)
		{
			if (player == null) return;
			_player = player;
			InitializeComponent();
			Icon = new Icon(GetType(), "Main.ico");
		}

		private void ButtonClick(object sender, EventArgs e)
		{
			try
			{
				if (_player.PlayerState == ITPlayerState.ITPlayerStatePlaying)
					_player.Pause();
				else
					_player.Play();
			}
			catch (COMException)
			{

			}
		}

		private void OnTrackChanged(object iTrack)
		{
			try
			{
				var current = iTrack as IITTrack ?? _player.CurrentTrack;
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
			if (Visible)
			{
				_player.OnPlayerPlayEvent += OnTrackChanged;
				_player.OnPlayerPlayingTrackChangedEvent += OnTrackChanged;
				OnTrackChanged(null);
			}
			else
			{
				_player.OnPlayerPlayEvent -= OnTrackChanged;
				_player.OnPlayerPlayingTrackChangedEvent -= OnTrackChanged;
			}
		}
	}
}
