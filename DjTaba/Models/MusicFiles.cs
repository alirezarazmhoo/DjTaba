using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class MusicFiles
	{
		public int Id { get; set; }
		public int MusicId { get; set; }
		public Music Music { get; set; }
		public string FileUrl { get; set; }
		public FileType Type { get; set; }
	}

	public enum FileType
	{
		Picture ,
		Video ,
		Other
	}

}
