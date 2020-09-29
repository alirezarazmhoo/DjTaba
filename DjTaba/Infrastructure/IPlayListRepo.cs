using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;

namespace DjTaba.Infrastructure
{
public	interface IPlayListRepo
	{
		Task<IEnumerable<PlayList>> GetAllPlayListAsync();
		Task<IEnumerable<PlayList>> GetAllNewstPlayListAsync();
		Task<IEnumerable<PlayList>> GetAllMostViewedPlayListAsync();
		Task<IEnumerable<PlayListToMusic>> GetPlaylistByIdAsync(int Id);
		Task AddViewToPlayList(int id , string address);
	}
}
