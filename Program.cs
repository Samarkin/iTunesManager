using System;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using iTunesLib;

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
			var player = new iTunesAppClass();
			player.OnAboutToPromptUserToQuitEvent += Application.Exit;

			// Hotkey service
			using (var hotkeyService = new HotkeyService(player))
			{
				var selectSongVisualService = new VisualService {
					Form = new SelectSongForm(player),
					MenuEntry = "&Select song"
				};

				hotkeyService.RegisterHotKey("SelectSong",
					(o, e) => selectSongVisualService.Activate());

				// Tray service
				using (new TrayService(new[] { selectSongVisualService,
					new VisualService {
						Form = new MainForm(player),
						MenuEntry = "Show &MiniPlayer"
					},
					new VisualService {
						Form = new SettingsForm(),
						MenuEntry = "S&ettings"
					}
				}))
				{
					using (new OSDService(player))
					{
						Application.Run();
					}
				}
			}
		}
	}
}
