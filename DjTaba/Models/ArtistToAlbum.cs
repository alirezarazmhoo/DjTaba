using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ArtistToAlbum
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ArtistId { get; set; }
		public Artist Artist { get; set; }
		public int? AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
