using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ClientToAlbum
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public int AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
