using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class Pudcast
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		//public int? GenreId { get; set; }
		//public Genre Genre { get; set; }
		public int MusicsCount { get; set; }
		public string ImageUrl { get; set; }
		public string ImageUrlThumbNail { get; set; }
		public long View { get; set; }
		public ICollection<GenreToPudcast> GenreToPudcasts { get; set; }

	}
}
