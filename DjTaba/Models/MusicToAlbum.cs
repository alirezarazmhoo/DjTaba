using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class MusicToAlbum
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? MusicId { get; set; }
		public Music Music { get; set; }
		public int? AlbumId { get; set; }
		public Album Album { get; set; }
		public string MusicThumbNailPicture { get; set; }


	}
}
