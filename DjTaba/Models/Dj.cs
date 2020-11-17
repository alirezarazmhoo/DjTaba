﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class Dj
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "FullName Is Empty")]
		public string FullName { get; set; }

		public string Biography { get; set; }

		public ICollection<DjImages> DjImages { get; set; }
	}
}
