using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			using (var control = new PlayerControllerService())
			{
				control.Player.OnAboutToPromptUserToQuitEvent += Application.Exit;

				// Hotkey service
				using (var hotkeyService = new HotkeyService())
				{
					control.RegisterHotkeyService(hotkeyService);

					var selectSongVisualService = new VisualService
					{
						Form = new SelectSongForm(control.Player),
						MenuEntry = "&Select song"
					};
					hotkeyService.RegisterHotKey("SelectSong",
						(o, e) => selectSongVisualService.Activate());

					var lyricsVisualService = new VisualService
					{
						Form = new LyricsForm(control),
						MenuEntry = "Show &Lyrics"
					};
					hotkeyService.RegisterHotKey("ShowLyrics",
						(o, e) => lyricsVisualService.Activate());

					// Tray service
					using (var trayService = new TrayService(new[] { selectSongVisualService,
						new VisualService {
							Form = new MainForm(control),
							MenuEntry = "Show &MiniPlayer"
						},
						lyricsVisualService,
						new VisualService {
							Form = new SettingsForm(),
							MenuEntry = "S&ettings"
						}
					}))
					{
						control.RegisterNotificationService(trayService);
						using (new OSDService(control))
						{
							Application.Run();
						}
					}
				}
			}
		}
	}
}
