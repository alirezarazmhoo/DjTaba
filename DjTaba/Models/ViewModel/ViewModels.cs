using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models.ViewModel
{
	public class EditViewModels
	{
		public string key { get; set; }
		public string value { get; set; }
	}
	
	public class ArtistPictureViewModels
	{
		public int id { get; set; }
		public string url { get; set; }

	}
	public class MusicFilesViewModels
	{
		public int id { get; set; }
		public string url { get; set; }
		public string target { get; set; }
		public FileType? FileType { get; set; }

		public string specialtypefile { get; set; }
	}
	public class ComboBoxViewModel
	{
		public int id { get; set; }
		public string name { get; set; }
	}

	public class AlbumAndDetailsViewModel
	{
		public Album Album { get; set; }
		public IEnumerable<MusicToAlbum> Musics { get; set; }
		public IEnumerable<ArtistToAlbum> Artists { get; set; }
		public IEnumerable<ImagesToAlbum> Images { get; set; }
	}
	public class SearchByEveryThingViewModel
	{
		public IEnumerable<AlbumChild> Album { get; set; }
		public IEnumerable<PlayListChild> PlayList { get; set; }
		public IEnumerable<MusicChild> Music { get; set; }

	}
	public sealed class AlbumChild : ChildBase
	{
	}
	public sealed class PlayListChild : ChildBase
	{
	}
	public sealed class MusicChild : ChildBase
	{
	}
	public abstract class ChildBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

	}
}
