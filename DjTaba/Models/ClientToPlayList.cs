using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ClientToPlayList
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public int PlayListId { get; set; }
		public PlayList PlayList { get; set; }
	}
}
