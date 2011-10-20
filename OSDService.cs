using System;
using System.Linq;
using System.Runtime.InteropServices;
using iTunesLib;
using System.IO;

namespace WindowsFormsApplication1
{
	class OSDService : IDisposable
	{
		private readonly iTunesAppClass _player;
		private readonly OSDForm _osd;

		public OSDService(iTunesAppClass player)
		{
			if (player == null) return;
			_player = player;
			_player.OnPlayerPlayEvent += OnPlayerEvent;
			_player.OnPlayerPlayingTrackChangedEvent += OnPlayerEvent;
			_player.OnPlayerStopEvent += OnPlayerEvent;
			_osd = new OSDForm();
		}

		public void OnPlayerEvent(object iTrack)
		{
			try
			{
				if (_player.PlayerState == ITPlayerState.ITPlayerStateStopped) return;

				var current = _player.CurrentTrack;
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
			_player.OnPlayerPlayEvent -= OnPlayerEvent;
			_player.OnPlayerPlayingTrackChangedEvent -= OnPlayerEvent;
			_player.OnPlayerStopEvent -= OnPlayerEvent;
		}
	}
}
