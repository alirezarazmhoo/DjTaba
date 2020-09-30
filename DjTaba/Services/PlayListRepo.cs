using DjTaba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
using DjTaba.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DjTaba.Models.ViewModel;
using DjTaba.Utility;

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
		public async Task<IEnumerable<PlayListChild>> GetSummaryAllPlayListAsync(int? pageNumber)
		{
			pageNumber = pageNumber == null ? 1 : pageNumber;
			List<PlayListChild> playListChildren = new List<PlayListChild>();
			foreach (var item in await _DbContext.PlayLists.Select(s=>new
			{ s.Id , s.Name , s.ImageUrlThumbNail})
				.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
			{
				playListChildren.Add(new PlayListChild() { Id = item.Id, 
					Name = item.Name, Url = item.ImageUrlThumbNail });
			}
			return  playListChildren; 
		}
		public async Task<IEnumerable<PlayListChild>> GetAllNewstPlayListAsync(int? pageNumber)
		{
			pageNumber = pageNumber == null ? 1 : pageNumber;
			List<PlayListChild> playListChildren = new List<PlayListChild>();
			foreach (var item in await _DbContext.PlayLists.Select(s => new
			{ s.Id, s.Name, s.ImageUrlThumbNail , s.CreateDate }).OrderByDescending(s=>s.CreateDate)
				.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
			{
				playListChildren.Add(new PlayListChild()
				{
					Id = item.Id,
					Name = item.Name,
					Url = item.ImageUrlThumbNail
				});
			}
			return playListChildren;
		}
		public async Task<IEnumerable<PlayListChild>> GetAllMostViewedPlayListAsync(int? pageNumber)
		{
			pageNumber = pageNumber == null ? 1 : pageNumber;
			List<PlayListChild> playListChildren = new List<PlayListChild>();
			foreach (var item in await _DbContext.PlayLists.Select(s => new
			{ s.Id, s.Name, s.ImageUrlThumbNail, s.View }).OrderByDescending(s => s.View)
				.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
			{
				playListChildren.Add(new PlayListChild()
				{
					Id = item.Id,
					Name = item.Name,
					Url = item.ImageUrlThumbNail
				});
			}
			return playListChildren;
		}
		public async Task<PlayListAndMusic> GetPlaylistByIdAsync(int Id)
		{
			PlayListAndMusic playListAndMusic = new PlayListAndMusic();
			List<Music> musics = new List<Music>();
			PlayList playList =await _DbContext.PlayLists.Include(s=>s.Genre).Where(s=>s.Id == Id).FirstOrDefaultAsync();
			if(playList is null)
			{
				return null;
			}
			foreach (var item in await _DbContext.PlayListToMusics.Include(s => s.Music).Where(s => s.PlayListId == Id).ToListAsync())
			{
				musics.Add(item.Music);
			}
			playListAndMusic.PlayList = playList;
			playListAndMusic.PlayListToMusics = musics;
			return playListAndMusic;
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
