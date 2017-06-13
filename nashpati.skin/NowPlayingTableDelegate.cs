using System;
using AppKit;
using Foundation;

namespace nashpati.skin
{
	public class NowPlayingTableDelegate : NSTableViewDelegate
	{
		private const string CellIdentifier = "ItemCell";
		private NowPlayingTableDataSource DataSource;

		public NowPlayingTableDelegate(NowPlayingTableDataSource source)
		{
			this.DataSource = source;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			PlaylistRow playlistRow = new PlaylistRow();
			playlistRow.SetPlaylistItem(DataSource.Items[(int)row]);
			return playlistRow;
		}
	}
}
