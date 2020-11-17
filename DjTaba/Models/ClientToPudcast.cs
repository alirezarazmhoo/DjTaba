using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ClientToPudcast
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public int PudcastId { get; set; }
		public Pudcast Pudcast { get; set; }
	}
}
