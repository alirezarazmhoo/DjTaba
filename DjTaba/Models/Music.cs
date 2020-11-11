using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class Music
	{
		public int Id { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public string Name { get; set; }
		public string Lyric { get; set; }
	    public string Arrangement { get; set; }
		public string CoverArt { get; set; }
		public string PhotoCreator { get; set; }
		public string ShortDescription { get; set; }
		public string Link { get; set; }
		public string Speed { get; set; }
		public string MusicKeys { get; set; }
		public string AbutMusic { get; set; }
		public string SongText { get; set; }
		public string MusicUrl { get; set; }
		public string PictureMusicUrl { get; set; }
		public DateTime RelaseDate { get; set; } = DateTime.MinValue;
		public DateTime MixDate { get; set; } = DateTime.MinValue;
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public int Size { get; set; } = 0;
		public int Quality { get; set; } = 0; 
		public ICollection<MusicFiles>  MusicFiles { get; set; }
		public ICollection<ArtistToMusic> ArtistToMusics { get; set; }
		public string PictureMusicUrlThumbNail { get; set; }

		public int Views { get; set; }

		//public ICollection<PlayListToMusic> PlayListToMusics { get; set; }
	}
}
