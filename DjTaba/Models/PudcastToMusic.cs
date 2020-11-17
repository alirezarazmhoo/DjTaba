using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class PudcastToMusic
	{
		public int Id { get; set; }
		public int? MusicId { get; set; }
		public Music Music { get; set; }
		public int? PudcastId { get; set; }
		public Pudcast  Pudcast { get; set; }
	}
}
