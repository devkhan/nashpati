using System;
using AppKit;
using Foundation;

namespace nashpati.skin
{
	public class NowPlayingTableDelegate : NSTableViewDelegate
	{
		private const string CellIdentifier = "ItemCell";
		private NowPlayingTableDataSource DataSource;
		private NSTableView Table;

		public NowPlayingTableDelegate(NowPlayingTableDataSource source, NSTableView table)
		{
			this.DataSource = source;
			this.Table = table;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			PlaylistRow playlistRow = new PlaylistRow();
			playlistRow.SetPlaylistItem(DataSource.Items[(int)row]);
			return playlistRow;
		}
	}
}
