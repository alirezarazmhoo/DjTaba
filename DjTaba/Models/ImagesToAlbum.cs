using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ImagesToAlbum
	{
		public int Id { get; set; }
        public string ImageUrl { get; set; }
		public int? AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
