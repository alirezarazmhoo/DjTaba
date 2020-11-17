using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class Video
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
		public string CoverUrl { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
	}
}
