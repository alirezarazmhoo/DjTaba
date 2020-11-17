using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class GenreToPudcast
	{
		public int Id { get; set; }
		public int GenreId { get; set; }
		public string Name { get; set; }
		public Genre Genre { get; set; }
		public int PudcastId { get; set; }
		public Pudcast Pudcast { get; set; }
	}
}
