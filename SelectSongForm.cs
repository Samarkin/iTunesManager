using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Helpers;
using iTunesLib;

namespace WindowsFormsApplication1
{

	public partial class SelectSongForm : Form
	{
		private readonly iTunesApp _player;
		private IITPlaylist _playlist;

		public SelectSongForm(iTunesApp player)
		{
			if (player == null) return;
			_player = player;
			InitializeComponent();
			Icon = new Icon(GetType(), "Main.ico");
			playButton.Tag = false;
			shuffleButton.Tag = true;
		}

		private IITPlaylist[] _playlists;

		private void SelectSongFormVisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
			{
				_playlists = _player.LibrarySource.Playlists.Cast<IITPlaylist>()
					.Where(plist => plist.Kind == ITPlaylistKind.ITPlaylistKindUser).ToArray();
				artistComboBox.Items.AddRange(_playlists.Select(plist => plist.Name).ToArray());
			}
			else
			{
				_playlist = null;
				artistComboBox.Items.Clear();
				songComboBox.Items.Clear();
				artistComboBox.Text = string.Empty;
				songComboBox.Text = string.Empty;
				artistComboBox.Focus();
			}
		}

		private void SelectSongFormClosing(object sender, FormClosingEventArgs e)
		{
			Hide();
			if (e.CloseReason != CloseReason.ApplicationExitCall)
				e.Cancel = true;
		}

		private void ArtistComboBoxLeave(object sender, EventArgs e)
		{
			songComboBox.Items.Clear();
			int idx = artistComboBox.FindStringExact(artistComboBox.Text);
			IEnumerable tracks = Enumerable.Empty<IITTrack>();
			// if selected playlist exists
			if (idx >= 0)
			{
				_playlist = _playlists[idx];
				tracks = _playlist.Tracks;
			}
			// if was entered part of the artist name
			else if(!string.IsNullOrEmpty(artistComboBox.Text))
			{
				_playlist = null;
				tracks = _player.LibraryPlaylist.SearchSafe(artistComboBox.Text, ITPlaylistSearchField.ITPlaylistSearchFieldArtists);
			}

			// populate second combobox
			foreach (var track in tracks.OfType<IITTrack>().Select(track => track.Name))
			{
				songComboBox.Items.Add(track);
			}
		}

		private void PlayButtonClick(object sender, EventArgs e)
		{
			const string noTrack = "Wrong track";
			// create new playlist if it is not exists yet
			if (_playlist == null)
			{
				_playlist = _player.CreatePlaylist(artistComboBox.Text);
				var x = (_playlist as IITUserPlaylist);
				if (x == null)
					// something bad happened
					return;
				// populating new playlist
				foreach (var tr in _player.LibraryPlaylist.SearchSafe(artistComboBox.Text, ITPlaylistSearchField.ITPlaylistSearchFieldArtists).OfType<IITTrack>())
				{
					object oTrack = tr;
					x.AddTrack(ref oTrack);
				}
			}

			// prepare playlist
			object oPlaylist = _playlist;
			_player.BrowserWindow.set_SelectedPlaylist(ref oPlaylist);
			if (_player.get_CanSetShuffle(ref oPlaylist))
			{
				var control = sender as Control;
				_playlist.Shuffle = control != null && control.Tag.Equals(true);
			}

			// find track
			var track = _playlist.SearchSafe(songComboBox.Text, ITPlaylistSearchField.ITPlaylistSearchFieldSongNames).OfType<IITTrack>().FirstOrDefault();
			if (track == null)
				MessageBox.Show(noTrack);
			else
				track.Play();

			Hide();
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
