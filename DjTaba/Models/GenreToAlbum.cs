using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class GenreToAlbum
	{
		public int Id { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public int AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
