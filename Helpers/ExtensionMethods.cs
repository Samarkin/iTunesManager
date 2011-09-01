using System.Collections;
using System.Linq;
using iTunesLib;

namespace WindowsFormsApplication1.Helpers
{
	static class ExtensionMethods
	{
		public static IEnumerable SearchSafe(this IITPlaylist playlist, string searchText, ITPlaylistSearchField searchFields)
		{
			if (string.IsNullOrEmpty(searchText)) return Enumerable.Empty<IITTrack>();
			return (IEnumerable)playlist.Search(searchText, searchFields) ?? Enumerable.Empty<IITTrack>();
		}
	}
}
