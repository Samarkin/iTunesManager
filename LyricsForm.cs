using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTunesLib;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
	public partial class LyricsForm : Form
	{
		private const string GetArtistUrlFormat = @"http://lyrics.wikia.com/api.php?artist={0}&fmt=text";
		private const string GetLyricsUrlFormat = @"http://lyrics.wikia.com/{0}:{1}";
		protected static Regex Regex = new Regex(@"<div class=['""]lyricbox['""]>[^<]*(<div.*</div>)*(?<lyrics>.*)<!--", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
		protected static Regex NewLine = new Regex(@"<br[ /]*>", RegexOptions.Compiled);
		protected static Regex CodedSymbol = new Regex(@"&#(?<value>[0-9]+);", RegexOptions.Compiled);
		protected static Regex ArtistName = new Regex(@"(?<artist>[^:]+):(?<title>.+)", RegexOptions.Compiled);

		private readonly PlayerControllerService _control;

		public LyricsForm(PlayerControllerService control)
		{
			_control = control;
			InitializeComponent();
			LyricsFormResized(this, new EventArgs());
		}

		private int _lastWidth, _lastHeight;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			const int radius = 8;
			int title = lblTitle.Height + lblTitle.Top;

			if (Width != _lastWidth && Height != _lastHeight)
			{
				var path = GetRoundedRectangle(radius, 0, 0, Width, Height);
				Region = new Region(path);

				_lastWidth = Width;
				_lastHeight = Height;
			}

			e.Graphics.FillRectangle(Brushes.Black, 0, title, Width, Height - title);
		}

		private GraphicsPath GetRoundedRectangle(int radius, int x, int y, int width, int height)
		{
			radius = Math.Min(Math.Min(radius, width / 2), height / 2);

			var path = new GraphicsPath();
			int d = radius * 2;
			path.AddArc(x, y, d, d, 180, 90);
			path.AddLine(x + radius, y, x + width - radius, y);
			path.AddArc(x + width - d, y, d, d, 270, 90);
			path.AddLine(x + width, y + radius, x + width, y + height - radius);
			path.AddArc(x + width - d, y + height - d, d, d, 0, 90);
			path.AddLine(x + radius, y + height, x + width - radius, y + height);
			path.AddArc(x, y + height - d, d, d, 90, 90);
			path.AddLine(x, y + radius, x, y + height - radius);

			return path;
		}

		private void LyricsFormVisibleChanged(object sender, EventArgs e)
		{
			var player = _control.Player;
			if (Visible)
			{
				player.OnPlayerPlayEvent += OnTrackChanged;
				player.OnPlayerPlayingTrackChangedEvent += OnTrackChanged;
				OnTrackChanged(null);
			}
			else
			{
				player.OnPlayerPlayEvent -= OnTrackChanged;
				player.OnPlayerPlayingTrackChangedEvent -= OnTrackChanged;
			}
		}

		private void OnTrackChanged(object iTrack)
		{
			try
			{
				var player = _control.Player;
				var current = iTrack as IITTrack ?? player.CurrentTrack;
				if (current == null) return;

				var file = current as IITFileOrCDTrack;
				if (file != null && !string.IsNullOrEmpty(file.Lyrics))
				{
					var artist = current.Artist;
					var title = current.Name;

					SetLyrics(file.Lyrics, string.Format("{0} - {1}", artist, title));
					return;
				}

				Action<SongFetching> doFetch = StartFetchLyrics;
				Invoke(doFetch, new SongFetching(current));
			}
			catch (COMException)
			{

			}
		}

		private class SongFetching
		{
			public WebClient WebClient;
			public readonly IITTrack Track;
			public readonly string Artist;
			public readonly string Title;

			public SongFetching(IITTrack track)
			{
				Track = track;
				Artist = track.Artist;
				Title = track.Name;
			}
		}

		private void StartFetchLyrics(SongFetching info)
		{
			lblTitle.Text = "Loading . . .";
			lblLyrics.Text = string.Empty;
			var uri = new Uri(string.Format(GetArtistUrlFormat, info.Artist));
			var client = new WebClient();
			info.WebClient = client;
			client.DownloadDataCompleted += VerifySongComplete;
			client.DownloadDataAsync(uri, info);
		}

		private void VerifySongComplete(object sender, DownloadDataCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				ReportError(e.Error);
				return;
			}

			try
			{
				var xmlString = Encoding.UTF8.GetString(e.Result);
				var artistName = ArtistName.Match(xmlString).Groups["artist"].Value;
				var state = (SongFetching)e.UserState;

				var songs = xmlString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
				var song = songs.FirstOrDefault(s => s.Equals(artistName + ":" + state.Title, StringComparison.CurrentCultureIgnoreCase));
				var title = state.Title;
				if(song != null)
					title = ArtistName.Match(song).Groups["title"].Value;
				//state.Artist = artistName;
				var client = state.WebClient;
				client.DownloadStringCompleted += DownloadLyricsComplete;
				var uri = new Uri(string.Format(GetLyricsUrlFormat, artistName, title));
				client.DownloadStringAsync(uri, state);
			}
			catch (Exception ex)
			{
				ReportError(ex);
			}
		}

		private void DownloadLyricsComplete(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				ReportError(e.Error);
				return;
			}

			try
			{
				var html = e.Result;
				var state = (SongFetching)e.UserState;
				var s = Regex.Match(html).Groups["lyrics"].ToString();
				if (!string.IsNullOrEmpty(s))
				{
					s = NewLine.Replace(s, "\n");
					s = CodedSymbol.Replace(s, m =>
						{
							int val;
							return int.TryParse(m.Groups["value"].ToString(), out val)
									? new string((char)val, 1)
									: m.Groups[0].ToString();
						});
					SetLyrics(s, string.Format("{0} - {1}", state.Artist, state.Title));

					var file = state.Track as IITFileOrCDTrack;
					if (file != null)
					{
						file.Lyrics = s;
						return;
					}
				}
				else
				{
					throw new Exception("No lyrics found");
				}
			}
			catch (Exception ex)
			{
				ReportError(ex);
			}
		}

		private void ReportError(Exception ex)
		{
			SetLyrics(ex.Message, "Error");
		}

		private void SetLyrics(string lyrics, string title)
		{
			Action doReportError = () =>
			{
				lblTitle.Text = title;
				lblLyrics.Text = lyrics;
			};
			Invoke(doReportError);
		}

		private void LyricsFormResized(object sender, EventArgs e)
		{
			var width = panel1.Width - SystemInformation.VerticalScrollBarWidth;
			lblLyrics.MaximumSize = new Size(width, 0);
		}

		private bool _isDragging;
		private Point _draggingFrom;
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			_isDragging = true;
			_draggingFrom = e.Location;
		}

		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			_isDragging = false;
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (_isDragging)
			{
				Top += e.Location.Y - _draggingFrom.Y;
				Left += e.Location.X - _draggingFrom.X;
			}
		}

		private void LyricsFormClosing(object sender, FormClosingEventArgs e)
		{
			Hide();
			if (e.CloseReason != CloseReason.ApplicationExitCall)
				e.Cancel = true;
		}

		private void CloseClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}

