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
	public class PudcastRepo : RepositoryBase<Pudcast>, IPudcastRepo
	{
		public PudcastRepo(ApplicationDbContext DbContext)
        : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<Pudcast>> GetAllPudcastAsync()
		{
		return await FindAll(null).Include(s => s.GenreToPudcasts)
		.OrderByDescending(s => s.Id)
		.ToListAsync();
		}
		public async Task<IEnumerable<PudcastChild>> GetSummaryAllPudcastAsync(int? pageNumber)
		{
		pageNumber = pageNumber == null ? 1 : pageNumber;
		List<PudcastChild> pudcastListChildren = new List<PudcastChild>();
		foreach (var item in await _DbContext.Pudcasts.Select(s => new
		{ s.Id, s.Name, s.ImageUrlThumbNail })
		.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
		{
		pudcastListChildren.Add(new PudcastChild()
		{
		Id = item.Id,
		Name = item.Name,
		Url = item.ImageUrlThumbNail
		});
		}
		return pudcastListChildren;
		}
		public async Task<IEnumerable<PudcastChild>> GetAllNewstPudcastAsync(int? pageNumber)
		{
			pageNumber = pageNumber == null ? 1 : pageNumber;
			List<PudcastChild> pudcastListChildren = new List<PudcastChild>();
			foreach (var item in await _DbContext.Pudcasts.Select(s => new
			{ s.Id, s.Name, s.ImageUrlThumbNail, s.CreateDate }).OrderByDescending(s => s.CreateDate)
				.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
			{
				pudcastListChildren.Add(new PudcastChild()
				{
					Id = item.Id,
					Name = item.Name,
					Url = item.ImageUrlThumbNail
				});
			}
			return pudcastListChildren;
		}
		public async Task<IEnumerable<PudcastChild>> GetAllMostViewedPudcastAsync(int? pageNumber)
		{
			pageNumber = pageNumber == null ? 1 : pageNumber;
			List<PudcastChild> pudcastListChildren = new List<PudcastChild>();
			foreach (var item in await _DbContext.PlayLists.Select(s => new
			{ s.Id, s.Name, s.ImageUrlThumbNail, s.View }).OrderByDescending(s => s.View)
				.Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
			{
				pudcastListChildren.Add(new PudcastChild()
				{
					Id = item.Id,
					Name = item.Name,
					Url = item.ImageUrlThumbNail
				});
			}
			return pudcastListChildren;
		}
		public async Task<PudcastAndMusic> GetPudcastByIdAsync(int Id)
		{
			PudcastAndMusic playListAndMusic = new PudcastAndMusic();
			List<MusicChild> musics = new List<MusicChild>();
			Pudcast pudcast = await _DbContext.Pudcasts.Include(s => s.GenreToPudcasts).Where(s => s.Id == Id).FirstOrDefaultAsync();
			if (pudcast is null)
			{
				return null;
			}
			foreach (var item in await _DbContext.PudcastToMusics.Include(s => s.Music).Where(s => s.PudcastId == Id).ToListAsync())
			{
				musics.Add(new MusicChild() { Id = item.MusicId.Value, Name = item.Music.Name, Url = item.Music.PictureMusicUrlThumbNail });
			}
			playListAndMusic.Pudcast = pudcast;
			playListAndMusic.PudcastToMusics = musics;
			return playListAndMusic;
		}
		public async Task AddViewToPudcast(int id, string address)
		{
			Pudcast pudcastitem = await _DbContext.Pudcasts.Where(s => s.Id == id).FirstOrDefaultAsync();
			ClientToPudcast _clientToPudcast = new ClientToPudcast();
			if (pudcastitem != null)
			{
				if (await _DbContext.ClientToPudcasts.AnyAsync(s => s.PudcastId == id && s.Ip == address) == false)
				{
					_clientToPudcast.Ip = address;
					_clientToPudcast.PudcastId = id;
					_DbContext.ClientToPudcasts.Add(_clientToPudcast);
					pudcastitem.View += 1;
					await _DbContext.SaveChangesAsync();
				}
			}
		}
		public async Task<IEnumerable<GetByGenreId>> GetPudcastByGenreIdAsync(int GenreId)
		{
			List<GetByGenreId> list = new List<GetByGenreId>();
			var Items = await _DbContext.GenreToPudcast.Where(s => s.GenreId == GenreId).Select(s => new { s.Pudcast.Name, s.PudcastId, s.Pudcast.ImageUrlThumbNail }).ToListAsync();
			foreach (var item in Items)
			{
				list.Add(new GetByGenreId() { Id = item.PudcastId, Name = item.Name, Url = item.ImageUrlThumbNail });
			}
			return list;
		}

	}
}
