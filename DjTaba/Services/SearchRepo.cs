using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Services
{
	public class SearchRepo : RepositoryBase<SearchByEveryThingViewModel>, ISearchRepo
	{		
		public SearchRepo(ApplicationDbContext DbContext)
		: base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<SearchByEveryThingViewModel> SearchByEveryThing(string txtsearch)
		{
			SearchByEveryThingViewModel searchByEveryThingViewModel = new SearchByEveryThingViewModel();
			List<AlbumChild> albumChildren = new List<AlbumChild>();
			List<PlayListChild> playListChildren = new List<PlayListChild>();
			List<MusicChild> musicChildren = new List<MusicChild>();
			foreach (var item in await _DbContext.Albums.Where(s => s.Name.Contains(txtsearch))
				.Select(s => new { Id = s.Id, Name = s.Name, Url = s.MainImageUrl }).ToListAsync() )
			{
				albumChildren.Add(new AlbumChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			foreach (var item in await _DbContext.PlayLists.Where(s => s.Name.Contains(txtsearch))
				.Select(s => new { Id = s.Id, Name = s.Name, Url = s.ImageUrl }).ToListAsync())
			{
				playListChildren.Add(new PlayListChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			foreach (var item in await _DbContext.Musics.Where(s => s.Name.Contains(txtsearch))
	       .Select(s => new { Id = s.Id, Name = s.Name, Url = s.PictureMusicUrl }).ToListAsync())
			{
				musicChildren.Add(new MusicChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			searchByEveryThingViewModel.Album = albumChildren;
			searchByEveryThingViewModel.PlayList = playListChildren;
			searchByEveryThingViewModel.Music = musicChildren;
			return searchByEveryThingViewModel; 
		}

	}
}
