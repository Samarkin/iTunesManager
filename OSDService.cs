using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using iTunesLib;
using System.IO;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	class OSDService : IDisposable
	{
		private readonly PlayerControllerService _controller;
		private readonly OSDForm _osd;
		private PausedForm _pausedForm;

		public OSDService(PlayerControllerService controller)
		{
			if (controller == null) return;
			_controller = controller;
			_controller.Player.OnPlayerPlayEvent += OnPlayerEvent;
			_controller.Player.OnPlayerPlayingTrackChangedEvent += OnPlayerEvent;
			_controller.Player.OnPlayerStopEvent += OnPlayerEvent;
			_osd = new OSDForm();
			ApplySettings();

			Settings.Default.SettingsSaving += SettingsSaving;
		}

		private void ApplySettings()
		{
			if (Settings.Default.OSDDisplayOnPause)
				_pausedForm = new PausedForm();
			else if (_pausedForm != null)
			{
				_pausedForm.Close();
				_pausedForm.Dispose();
				_pausedForm = null;
			}
		}

		private void SettingsSaving(object sender, CancelEventArgs e)
		{
			ApplySettings();
		}

		public void OnPlayerEvent(object iTrack)
		{
			try
			{
				var player = _controller.Player;
				if (player.PlayerState == ITPlayerState.ITPlayerStateStopped)
				{
					if(_pausedForm != null)
						_pausedForm.Start();
					return;
				}

				var current = player.CurrentTrack;
				var artwork = current.Artwork.OfType<IITArtwork>().FirstOrDefault();
				string artworkFileName = null;
				try
				{
					if (artwork != null)
					{
						artworkFileName = Path.GetTempFileName();
						artwork.SaveArtworkToFile(artworkFileName);
					}

					var name = (current.TrackNumber >= 1)
						? string.Format("{0}. {1}", current.TrackNumber, current.Name)
						: current.Name;
					var album = string.Format("{0} ({1})", current.Album, current.Year);
					_osd.DisplayOSD(name, current.Duration, current.Rating, current.Artist, album, artworkFileName);
				}
				finally
				{
					if(artworkFileName!= null) File.Delete(artworkFileName);
				}
			}
			catch (COMException)
			{
			}

		}

		public bool Disposed { get; private set; }

		public void Dispose()
		{
			if (Disposed) return;

			Disposed = true;
			_osd.Close();
			_osd.Dispose();
			_controller.Player.OnPlayerPlayEvent -= OnPlayerEvent;
			_controller.Player.OnPlayerPlayingTrackChangedEvent -= OnPlayerEvent;
			_controller.Player.OnPlayerStopEvent -= OnPlayerEvent;

			if (_pausedForm != null)
			{
				_pausedForm.Close();
				_pausedForm.Dispose();
			}
		}
	}
}
