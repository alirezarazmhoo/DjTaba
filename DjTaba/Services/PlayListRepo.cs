using DjTaba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
using DjTaba.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Services
{
	public class PlayListRepo : RepositoryBase<PlayList>, IPlayListRepo
	{
		public PlayListRepo(ApplicationDbContext DbContext)
	   : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<PlayList>> GetAllPlayListAsync()
		{
			return await FindAll(null).Include(s=>s.Genre)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}

		public async Task<IEnumerable<PlayList>> GetAllNewstPlayListAsync()
		{
			return await FindAll(null).Include(s => s.Genre)
			  .ToListAsync();
		}

		public async Task<IEnumerable<PlayList>> GetAllMostViewedPlayListAsync()
		{
			return await FindAll(null).Include(s => s.Genre).OrderByDescending(s=>s.View).Take(10)
			  .ToListAsync();
		}
		public async Task<IEnumerable<PlayListToMusic>> GetPlaylistByIdAsync(int Id)
		{
			var playListToMusic =await _DbContext.PlayListToMusics.Where(s => s.PlayListId == Id).Include(s => s.Music).ToListAsync();
			return  playListToMusic;
		}
		public async Task AddViewToPlayList(int id , string address)
		{
			PlayList playListitem =await _DbContext.PlayLists.Where(s => s.Id == id).FirstOrDefaultAsync();
			ClientToPlayList _clientToPlayList = new ClientToPlayList();
			if(playListitem != null)
			{
				if(await _DbContext.ClientToPlayLists.AnyAsync(s=>s.PlayListId == id && s.Ip == address) == false)
				{
					_clientToPlayList.Ip = address;
					_clientToPlayList.PlayListId = id;
					_DbContext.ClientToPlayLists.Add(_clientToPlayList);
					playListitem.View += 1;
				await _DbContext.SaveChangesAsync();
				}
			}
		}
	}
}
