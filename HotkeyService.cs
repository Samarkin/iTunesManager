using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsFormsApplication1.Helpers;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public class HotkeyService : IDisposable
	{
		private readonly List<string> _settings;
		private readonly List<EventHandler<KeyPressedEventArgs>> _handlers;
		private readonly Queue<KeyboardHook> _hooks;

		private const string ModifiersSettingFormat = "{0}Modifiers";
		private const string KeysSettingFormat = "{0}Hotkey";

		public HotkeyService()
		{
			_hooks = new Queue<KeyboardHook>();
			_settings = new List<string>();
			_handlers = new List<EventHandler<KeyPressedEventArgs>>();

			Settings.Default.SettingsSaving += SettingsSaving;
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
