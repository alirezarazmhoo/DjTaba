using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class Album
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Please Enter A Name")]
		public string Name { get; set; }
		//public int GenreId { get; set; }
		//public Genre Genre { get; set; }
		public string Description { get; set; }
		public string PhotoCreator { get; set; }
		public DateTime PublishedDate { get; set; }
		public string MainImageUrl { get; set; }
		public string MainImageUrlThumbNail { get; set; }
		public long View { get; set; }
		public ICollection<GenreToAlbum> GenreToAlbums { get; set; }
		public ICollection<MusicToAlbum> MusicToAlbums { get; set; }
		public ICollection<ImagesToAlbum>  ImagesToAlbums { get; set; }
		public ICollection<ArtistToAlbum> ArtistToAlbums { get; set; }
	}
}
