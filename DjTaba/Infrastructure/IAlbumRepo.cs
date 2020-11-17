using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
using DjTaba.Models.ViewModel;

namespace DjTaba.Infrastructure
{
	public interface IAlbumRepo
	{
		Task<IEnumerable<Album>> GetAllAlbumsAsync();
		Task<IEnumerable<Album>> GetAllNewstsAlbumsAsync();
		Task<IEnumerable<Album>> GetAllMostViewedAlbumsAsync();
		Task<AlbumAndDetailsViewModel> GetAlbumByIdAsync(int Id);
		Task AddViewToAlbum(int id, string address);
		Task<IEnumerable<GetByGenreId>> GetAlbumByGenreIdAsync(int GenreId);
	}
}
