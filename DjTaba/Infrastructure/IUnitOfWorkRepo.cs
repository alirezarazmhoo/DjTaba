using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
	public  interface IUnitOfWorkRepo
	{
		IArtistRepo IArtistRepo { get; }
		IGenreRepo IGenreRepo { get; }
		IMusicRepo IMusicRepo { get; }
		IVideoRepo IVideoRepo { get; }
		IPlayListRepo IPlayListRepo { get; }
		IAlbumRepo IAlbumRepo { get; }
		ISearchRepo ISearchRepo { get; }

		Task SaveAsync();
	}
}
