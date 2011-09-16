using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsApplication1.Helpers;
using iTunesLib;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public class HotkeyService : IDisposable
	{
		private readonly List<KeyboardHook> _hooks;
		private readonly iTunesAppClass _player;

		public HotkeyService(iTunesAppClass player)
		{
			if(player == null) return;
			_player = player;

			_hooks = new List<KeyboardHook>();

			RegisterHotKey(Settings.Default.PlayPauseModifiers, Settings.Default.PlayPauseHotkey, PlayPause);
			RegisterHotKey(Settings.Default.NextTrackModifiers, Settings.Default.NextTrackHotkey, NextTrack);
			RegisterHotKey(Settings.Default.PrevTrackModifiers, Settings.Default.PrevTrackHotkey, PrevTrack);

			Application.ApplicationExit += ApplicationExit;
		}

		public void RegisterHotKey(ModifierKeys modifier, Keys key, EventHandler<KeyPressedEventArgs> handler)
		{
			var newHook = new KeyboardHook();
			try
			{
				newHook.KeyPressed += handler;
				newHook.RegisterHotKey(modifier, key);
				_hooks.Add(newHook);
			}
			catch (InvalidOperationException e)
			{
				MessageBox.Show(e.Message + "\n" + (modifier != ModifierKeys.None ? modifier.ToString() + " + " : "") + key.ToString(), "Error");
				newHook.Dispose();
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

		void ApplicationExit(object sender, EventArgs e)
		{
			Dispose();
		}

		public void Dispose()
		{
			foreach (var hook in _hooks)
			{
				hook.Dispose();
			}
			_hooks.Clear();
		}
	}
}
