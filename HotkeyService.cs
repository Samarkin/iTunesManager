using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsApplication1.Helpers;
using iTunesLib;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public class HotkeyService : IDisposable
	{
		private readonly List<string> _settings;
		private readonly List<EventHandler<KeyPressedEventArgs>> _handlers;
		private readonly Queue<KeyboardHook> _hooks;
		private readonly iTunesAppClass _player;

		private const string ModifiersSettingFormat = "{0}Modifiers";
		private const string KeysSettingFormat = "{0}Hotkey";

		public HotkeyService(iTunesAppClass player)
		{
			if(player == null) return;
			_player = player;

			_hooks = new Queue<KeyboardHook>();
			_settings = new List<string>();
			_handlers = new List<EventHandler<KeyPressedEventArgs>>();

			RegisterHotKey("PlayPause", PlayPause);
			RegisterHotKey("NextTrack", NextTrack);
			RegisterHotKey("PrevTrack", PrevTrack);

			RegisterHotKey("ChangeWindowSize", ChangeWindowSize);

			RegisterHotKey("SetNoStars", (o, e) => AssignStars(0));
			RegisterHotKey("SetOneStar", (o, e) => AssignStars(20));
			RegisterHotKey("SetTwoStars", (o, e) => AssignStars(40));
			RegisterHotKey("SetThreeStars", (o, e) => AssignStars(60));
			RegisterHotKey("SetFourStars", (o, e) => AssignStars(80));
			RegisterHotKey("SetFiveStars", (o, e) => AssignStars(100));

			Settings.Default.SettingsSaving += SettingsSaving;
		}

		private void ChangeWindowSize(object sender, KeyPressedEventArgs e)
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

		private void SettingsSaving(object sender, CancelEventArgs e)
		{
			RefreshHooks();
		}

		public void RegisterHotKey(string settingName, EventHandler<KeyPressedEventArgs> handler)
		{
			_settings.Add(settingName);
			_handlers.Add(handler);
			var newHook = CreateHook(settingName, handler);
			if(newHook != null)
				_hooks.Enqueue(newHook);
		}

		public void RefreshHooks()
		{
			DestroyHooks();
			int n = _settings.Count;
			for (int i = 0; i < n; i++)
			{
				var newHook = CreateHook(_settings[i], _handlers[i]);
				if (newHook != null)
					_hooks.Enqueue(newHook);
			}
		}

		private KeyboardHook CreateHook(string settingName, EventHandler<KeyPressedEventArgs> handler)
		{
			var modifier = ModifierKeys.None;
			var key = Keys.None;
			var newHook = new KeyboardHook();
			try
			{
				modifier = GetSetting<ModifierKeys>(string.Format(ModifiersSettingFormat, settingName));
				key = GetSetting<Keys>(string.Format(KeysSettingFormat, settingName));
				if(key == Keys.None)
				{
					newHook.Dispose();
					return null;
				}
				newHook.KeyPressed += handler;
				newHook.RegisterHotKey(modifier, key);
				return newHook;
			}
			catch (InvalidOperationException e)
			{
				MessageBox.Show(e.Message + "\n" + (modifier != ModifierKeys.None ? modifier.ToString() + " + " : "") + key.ToString(), "Error");
				newHook.Dispose();
				return null;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error");
				newHook.Dispose();
				return null;
			}
		}

		private T GetSetting<T>(string name) 
		{
			var setting = Settings.Default[name];
			if(setting == null)
				throw new Exception(string.Format("Cannot find setting named \"{0}\"!", name));

			return (T)setting;
		}

		private void AssignStars(int rating)
		{
			try
			{
				_player.CurrentTrack.Rating = rating;
			}
			catch (COMException)
			{

			}
		}

		private void PlayPause(object sender, KeyPressedEventArgs e)
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

		private void NextTrack(object sender, KeyPressedEventArgs e)
		{
			try
			{
				_player.NextTrack();
			}
			catch (COMException)
			{

			}
		}

		private void PrevTrack(object sender, KeyPressedEventArgs e)
		{
			try
			{
				_player.PreviousTrack();
			}
			catch (COMException)
			{

			}
		}

		private void DestroyHooks()
		{
			int n = _hooks.Count;
			for (int i = 0; i < n; i++)
			{
				var hook = _hooks.Dequeue();
				hook.Dispose();
			}
		}

		public void Dispose()
		{
			DestroyHooks();
		}
	}
}
