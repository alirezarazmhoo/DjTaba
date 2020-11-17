using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class GenreToPlaylist
	{
		public int Id { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public string Name { get; set; }

		public int PlayListId { get; set; }
		public PlayList PlayList { get; set; }
	}
}
