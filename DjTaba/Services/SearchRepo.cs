using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
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
		public async Task<SearchByEveryThingViewModel> SearchByEveryThing(string txtsearch , int? pageNumber)
		{
			SearchByEveryThingViewModel searchByEveryThingViewModel = new SearchByEveryThingViewModel();
			List<AlbumChild> albumChildren = new List<AlbumChild>();
			List<PlayListChild> playListChildren = new List<PlayListChild>();
			List<MusicChild> musicChildren = new List<MusicChild>();
			List<Video> videos = new List<Video>();
			List<Artist> artists = new List<Artist>();
		    pageNumber = pageNumber == null ? 1 : pageNumber;
			foreach (var item in await _DbContext.Albums.Where(s => s.Name.Contains(txtsearch))
				.Select(s => new { Id = s.Id, Name = s.Name, Url = s.MainImageUrl }).Skip((pageNumber.Value - 1)
		   * 10).Take(10).ToListAsync())
			{
				albumChildren.Add(new AlbumChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			foreach (var item in await _DbContext.PlayLists.Where(s => s.Name.Contains(txtsearch))
				.Select(s => new { Id = s.Id, Name = s.Name, Url = s.ImageUrl }).Skip((pageNumber.Value - 1)
				* 10).Take(10).ToListAsync())
			{
				playListChildren.Add(new PlayListChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			foreach (var item in await _DbContext.Musics.Where(s => s.Name.Contains(txtsearch))
	       .Select(s => new { Id = s.Id, Name = s.Name, Url = s.PictureMusicUrl }).Skip((pageNumber.Value - 1)
		   * 10).Take(10).ToListAsync())
			{
				musicChildren.Add(new MusicChild() { Id = item.Id, Name = item.Name, Url = item.Url });
			}
			foreach (var item in await _DbContext.Videos.Where(s => s.Name.Contains(txtsearch))
     	   .Select(s => new { Id = s.Id, Name = s.Name, Url = s.Url  , s.CoverUrl}).Skip((pageNumber.Value - 1) *
		   10).Take(10).ToListAsync())
			{
				videos.Add(new Video() { Id = item.Id, Name = item.Name, Url = item.Url , CoverUrl = item.CoverUrl });
			}
			foreach (var item in await _DbContext.Artists.Where(s => s.FullName.Contains(txtsearch))
		.Select(s => new { Id = s.Id, Name = s.FullName, Url = s.ArtistImages }).Skip((pageNumber.Value - 1) * 10)
		.Take(10).ToListAsync())
			{
				artists.Add(new Artist() { Id = item.Id, FullName = item.Name, ArtistImages = item.Url });
			}
			searchByEveryThingViewModel.Album = albumChildren;
			searchByEveryThingViewModel.PlayList = playListChildren;
			searchByEveryThingViewModel.Music = musicChildren;
			searchByEveryThingViewModel.Videos = videos;
			searchByEveryThingViewModel.Artists = artists; 
			return searchByEveryThingViewModel; 
		}

	}
}
