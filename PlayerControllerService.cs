using System;
using System.Runtime.InteropServices;
using iTunesLib;

namespace WindowsFormsApplication1
{
	public class PlayerControllerService : IDisposable
	{
		private iTunesApp _player;
		private INotificationService _notificationService;

		public PlayerControllerService()
		{
			_player = new iTunesAppClass();
		}

		public void RegisterHotkeyService(HotkeyService hotkeyService)
		{
			hotkeyService.RegisterHotKey("PlayPause", (o,e) => PlayPause());
			hotkeyService.RegisterHotKey("NextTrack", (o, e) => NextTrack());
			hotkeyService.RegisterHotKey("PrevTrack", (o, e) => PrevTrack());

			hotkeyService.RegisterHotKey("ChangeWindowSize", (o, e) => ChangeWindowSize());
			hotkeyService.RegisterHotKey("RepeatCurrentSong", (o, e) => RepeatCurrentSong());

			hotkeyService.RegisterHotKey("SetNoStars", (o, e) => AssignStars(0));
			hotkeyService.RegisterHotKey("SetOneStar", (o, e) => AssignStars(20));
			hotkeyService.RegisterHotKey("SetTwoStars", (o, e) => AssignStars(40));
			hotkeyService.RegisterHotKey("SetThreeStars", (o, e) => AssignStars(60));
			hotkeyService.RegisterHotKey("SetFourStars", (o, e) => AssignStars(80));
			hotkeyService.RegisterHotKey("SetFiveStars", (o, e) => AssignStars(100));
		}

		public void RegisterNotificationService(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		internal iTunesApp Player
		{
			get { return _player; }
		}

		public void RepeatCurrentSong()
		{
			try
			{
				object playlist = _player.CurrentPlaylist;
				if (playlist != null && _player.get_CanSetSongRepeat(ref playlist))
				{
					if (_player.CurrentPlaylist.SongRepeat == ITPlaylistRepeatMode.ITPlaylistRepeatModeOff)
					{
						_player.CurrentPlaylist.SongRepeat = ITPlaylistRepeatMode.ITPlaylistRepeatModeOne;
						ShowNotification("This song will be repeated");
					}
					else
					{
						_player.CurrentPlaylist.SongRepeat = ITPlaylistRepeatMode.ITPlaylistRepeatModeOff;
						ShowNotification("Songs will change one another");
					}
				}
			}
			catch (COMException)
			{

			}
		}

		private void ShowNotification(string message)
		{
			if (_notificationService != null)
				_notificationService.Notify(message);
		}

		public void ChangeWindowSize()
		{
			try
			{
				var mainWindow = _player.BrowserWindow;
				if (mainWindow != null)
				{
					mainWindow.MiniPlayer = !mainWindow.MiniPlayer;
				}
			}
			catch (COMException)
			{

			}
		}

		public void AssignStars(int rating)
		{
			try
			{
				_player.CurrentTrack.Rating = rating;
			}
			catch (COMException)
			{

			}
		}

		public void PlayPause()
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

		public void NextTrack()
		{
			try
			{
				_player.NextTrack();
			}
			catch (COMException)
			{

			}
		}

		public void PrevTrack()
		{
			try
			{
				_player.PreviousTrack();
			}
			catch (COMException)
			{

			}
		}

		public void Dispose()
		{

		}
	}
}
