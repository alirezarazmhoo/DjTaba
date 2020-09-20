using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class ArtistImages
	{
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
