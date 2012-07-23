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
		[Description("Play/pause")]
		public System.Windows.Forms.Keys PlayPauseHotkey
		{
			get { return _settings.PlayPauseHotkey; }
			set { _settings.PlayPauseHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Play/pause")]
		public Helpers.ModifierKeys PlayPauseModifiers
		{
			get { return _settings.PlayPauseModifiers; }
			set { _settings.PlayPauseModifiers = value; }
		}

		[Category("Hotkeys")]
		[Description("Skip to the next track")]
		public System.Windows.Forms.Keys NextTrackHotkey
		{
			get { return _settings.NextTrackHotkey; }
			set { _settings.NextTrackHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Skip to the next track")]
		public Helpers.ModifierKeys NextTrackModifiers
		{
			get { return _settings.NextTrackModifiers; }
			set { _settings.NextTrackModifiers = value; }
		}

		[Category("Hotkeys")]
		[Description("Rewind to the previous track")]
		public System.Windows.Forms.Keys PrevTrackHotkey
		{
			get { return _settings.PrevTrackHotkey; }
			set { _settings.PrevTrackHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Rewind to the previous track")]
		public Helpers.ModifierKeys PrevTrackModifiers
		{
			get { return _settings.PrevTrackModifiers; }
			set { _settings.PrevTrackModifiers = value; }
		}

		[Category("Hotkeys")]
		[Description("Open \"Select Song\" window")]
		public System.Windows.Forms.Keys SelectSongHotkey
		{
			get { return _settings.SelectSongHotkey; }
			set { _settings.SelectSongHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Open \"Select Song\" window")]
		public Helpers.ModifierKeys SelectSongModifiers
		{
			get { return _settings.SelectSongModifiers; }
			set { _settings.SelectSongModifiers = value; }
		}

		[Category("Hotkeys")]
		[Description("Change size of the main iTunes window")]
		public System.Windows.Forms.Keys ChangeWindowSizeHotkey
		{
			get { return _settings.ChangeWindowSizeHotkey; }
			set { _settings.ChangeWindowSizeHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Change size of the main iTunes window")]
		public Helpers.ModifierKeys ChangeWindowSizeModifiers
		{
			get { return _settings.ChangeWindowSizeModifiers; }
			set { _settings.ChangeWindowSizeModifiers = value; }
		}

		[Category("Hotkeys")]
		[Description("Toggle repetition of the current song")]
		public System.Windows.Forms.Keys RepeatCurrentSongHotkey
		{
			get { return _settings.RepeatCurrentSongHotkey; }
			set { _settings.RepeatCurrentSongHotkey = ValidateKey(value); }
		}

		[Category("Hotkeys")]
		[Description("Toggle repetition of the current song")]
		public Helpers.ModifierKeys RepeatCurrentSongModifiers
		{
			get { return _settings.RepeatCurrentSongModifiers; }
			set { _settings.RepeatCurrentSongModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("No stars hotkey")]
		[Description("Assign no stars rating to the current track")]
		public System.Windows.Forms.Keys SetNoStarsHotkey
		{
			get { return _settings.SetNoStarsHotkey; }
			set { _settings.SetNoStarsHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("No stars modifiers")]
		[Description("Assign no stars rating to the current track")]
		public Helpers.ModifierKeys SetNoStarsModifiers
		{
			get { return _settings.SetNoStarsModifiers; }
			set { _settings.SetNoStarsModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("One star hotkey")]
		[Description("Assign one star rating to the current track")]
		public System.Windows.Forms.Keys SetOneStarHotkey
		{
			get { return _settings.SetOneStarHotkey; }
			set { _settings.SetOneStarHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("One star modifiers")]
		[Description("Assign one star rating to the current track")]
		public Helpers.ModifierKeys SetOneStarModifiers
		{
			get { return _settings.SetOneStarModifiers; }
			set { _settings.SetOneStarModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("Two stars hotkey")]
		[Description("Assign two stars rating to the current track")]
		public System.Windows.Forms.Keys SetTwoStarsHotkey
		{
			get { return _settings.SetTwoStarsHotkey; }
			set { _settings.SetTwoStarsHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("Two stars modifiers")]
		[Description("Assign two stars rating to the current track")]
		public Helpers.ModifierKeys SetTwoStarsModifiers
		{
			get { return _settings.SetTwoStarsModifiers; }
			set { _settings.SetTwoStarsModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("Three stars hotkey")]
		[Description("Assign three stars rating to the current track")]
		public System.Windows.Forms.Keys SetThreeStarsHotkey
		{
			get { return _settings.SetThreeStarsHotkey; }
			set { _settings.SetThreeStarsHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("Three stars modifiers")]
		[Description("Assign three stars rating to the current track")]
		public Helpers.ModifierKeys SetThreeStarsModifiers
		{
			get { return _settings.SetThreeStarsModifiers; }
			set { _settings.SetThreeStarsModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("Four stars hotkey")]
		[Description("Assign four stars rating to the current track")]
		public System.Windows.Forms.Keys SetFourStarsHotkey
		{
			get { return _settings.SetFourStarsHotkey; }
			set { _settings.SetFourStarsHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("Four stars modifiers")]
		[Description("Assign four stars rating to the current track")]
		public Helpers.ModifierKeys SetFourStarsModifiers
		{
			get { return _settings.SetFourStarsModifiers; }
			set { _settings.SetFourStarsModifiers = value; }
		}

		[Category("Stars")]
		[DisplayName("Five stars hotkey")]
		[Description("Assign five stars rating to the current track")]
		public System.Windows.Forms.Keys SetFiveStarsHotkey
		{
			get { return _settings.SetFiveStarsHotkey; }
			set { _settings.SetFiveStarsHotkey = value; }
		}
		[Category("Stars")]
		[DisplayName("Five stars modifiers")]
		[Description("Assign five stars rating to the current track")]
		public Helpers.ModifierKeys SetFiveStarsModifiers
		{
			get { return _settings.SetFiveStarsModifiers; }
			set { _settings.SetFiveStarsModifiers = value; }
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
