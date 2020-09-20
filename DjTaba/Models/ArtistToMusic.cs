﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ArtistToMusic
	{
		public int Id { get; set; }
		public int ArtistId { get; set; }
		public string Name { get; set; }
		public Artist Artist { get; set; }
		public int MusicId { get; set; }
		public Music Music { get; set; }
	}
}
