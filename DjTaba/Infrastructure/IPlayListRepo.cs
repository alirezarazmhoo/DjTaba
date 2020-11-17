using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
using DjTaba.Models.ViewModel;

namespace DjTaba.Infrastructure
{
public	interface IPlayListRepo
	{
		Task<IEnumerable<PlayList>> GetAllPlayListAsync();
		Task<IEnumerable<PlayListChild>> GetAllNewstPlayListAsync(int? pageNumber);
		Task<IEnumerable<PlayListChild>> GetAllMostViewedPlayListAsync(int? pageNumber);
		Task<PlayListAndMusic> GetPlaylistByIdAsync(int Id);
		Task<IEnumerable<PlayListChild>> GetSummaryAllPlayListAsync(int? pageNumber);
		Task AddViewToPlayList(int id , string address);
		Task<IEnumerable<GetByGenreId>> GetPlayListByGenreIdAsync(int GenreId); 
	}
}
