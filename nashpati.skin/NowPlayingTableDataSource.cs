using System;
using System.Collections.Generic;
using AppKit;

namespace nashpati.skin
{
	public class NowPlayingTableDataSource : NSTableViewDataSource
	{
		public List<PlaylistItem> Items { get; set; } = new List<PlaylistItem>();

		public NowPlayingTableDataSource()
		{
		}

		public override nint GetRowCount(NSTableView tableView)
		{
			return Items.Count;
		}
	}
}
