using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class PlayListToMusic
	{
		public int Id { get; set; }
		public int? MusicId { get; set; }
		public Music Music { get; set; }
		public int? PlayListId { get; set; }
		public PlayList PlayList { get; set; }
	}
}
