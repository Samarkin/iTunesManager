using System;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	internal sealed class SettingsWrapper
	{
		private readonly Settings _settings;

		public SettingsWrapper()
			: this(Settings.Default)
		{
		}

		public SettingsWrapper(Settings settings)
		{
			_settings = settings;
		}

		public void Save()
		{
			_settings.Save();
		}

		private Keys ValidateKey(Keys key)
		{
			return key & Keys.KeyCode;
		}

		[Category("Hotkeys")]
		public System.Windows.Forms.Keys PlayPauseHotkey
		{
			get { return _settings.PlayPauseHotkey; }
			set { _settings.PlayPauseHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		public Helpers.ModifierKeys PlayPauseModifiers
		{
			get { return _settings.PlayPauseModifiers; }
			set { _settings.PlayPauseModifiers = value; }
		}

		[Category("Hotkeys")]
		public System.Windows.Forms.Keys NextTrackHotkey
		{
			get { return _settings.NextTrackHotkey; }
			set { _settings.NextTrackHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		public Helpers.ModifierKeys NextTrackModifiers
		{
			get { return _settings.NextTrackModifiers; }
			set { _settings.NextTrackModifiers = value; }
		}

		[Category("Hotkeys")]
		public System.Windows.Forms.Keys PrevTrackHotkey
		{
			get { return _settings.PrevTrackHotkey; }
			set { _settings.PrevTrackHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		public Helpers.ModifierKeys PrevTrackModifiers
		{
			get { return _settings.PrevTrackModifiers; }
			set { _settings.PrevTrackModifiers = value; }
		}

		[Category("Hotkeys")]
		public System.Windows.Forms.Keys SelectSongHotkey
		{
			get { return _settings.SelectSongHotkey; }
			set { _settings.SelectSongHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		public Helpers.ModifierKeys SelectSongModifiers
		{
			get { return _settings.SelectSongModifiers; }
			set { _settings.SelectSongModifiers = value; }
		}

		[Category("OSD")]
		[DefaultValue(0.85)]
		[Description("Opacity of the OSD window, where 0 stands for totally invisible and 1 for totally opaque.")]
		public double Opacity
		{
			get { return _settings.OSDOpacity; }
			set {
				_settings.OSDOpacity = Math.Max(Math.Min(value, 1), 0);
			}
		}

		[Category("OSD")]
		[DefaultValue(5000)]
		[Description("Display time of the OSD window in milliseconds (not including fade in and out time).")]
		public int DisplayTime
		{
			get { return _settings.OSDDisplayTime; }
			set { _settings.OSDDisplayTime = value; }
		}

		[Category("OSD")]
		[DefaultValue(Helpers.OSDPosition.ScreenBottom)]
		[Description("Position on the screen where OSD window will appear")]
		public Helpers.OSDPosition Position
		{
			get { return _settings.OSDPosition; }
			set { _settings.OSDPosition = value; }
		}

		[Category("OSD")]
		[DefaultValue(false)]
		[Description("If true, the word PAUSED will flash when pausing the track")]
		public bool DisplayOnPause
		{
			get { return _settings.OSDDisplayOnPause; }
			set { _settings.OSDDisplayOnPause = value; }
		}
	}
}
