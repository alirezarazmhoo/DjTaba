﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ClientToMusic
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public int MusicId { get; set; }
		public Music Music { get; set; }
	}
}
