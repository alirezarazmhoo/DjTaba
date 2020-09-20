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



}
