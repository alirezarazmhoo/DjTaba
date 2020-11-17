using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class DjImages
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public int DjId { get; set; }
		public Dj Dj { get; set; }
	}
}
