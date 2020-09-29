using DjTaba.Data;
using DjTaba.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;


namespace DjTaba.Services
{
	public class UnitOfWork : IUnitOfWorkRepo
	{
		private ApplicationDbContext _DbContext;
		private IArtistRepo _IArtistRepo;
		private IGenreRepo _IGenreRepo;
		private IMusicRepo _IMusicRepo;
		private IVideoRepo _IVideoRepo;
		private IPlayListRepo _IPlayListRepo;
		private IAlbumRepo _IAlbumRepo;
		private ISearchRepo _ISearchRepo;
		public UnitOfWork(ApplicationDbContext DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task SaveAsync()
		{
		await	_DbContext.SaveChangesAsync();
		}
		public IArtistRepo IArtistRepo
		{
			get
			{
				return _IArtistRepo = _IArtistRepo ?? new ArtistRepo(_DbContext);
			}
		}
		public IGenreRepo IGenreRepo
		{
			get
			{
				return _IGenreRepo = _IGenreRepo ?? new GenreRepo(_DbContext);
			}
		}
		public IMusicRepo IMusicRepo
		{
			get
			{
				return _IMusicRepo = _IMusicRepo ?? new MusicRepo(_DbContext);
			}
		}
		public IVideoRepo IVideoRepo
		{
			get
			{
				return _IVideoRepo = _IVideoRepo ?? new VideoRepo(_DbContext);
			}
		}
		public IPlayListRepo IPlayListRepo
		{
			get
			{
				return _IPlayListRepo = _IPlayListRepo ?? new PlayListRepo(_DbContext);
			}
		}
		public IAlbumRepo IAlbumRepo
		{
			get
			{
				return _IAlbumRepo = _IAlbumRepo ?? new AlbumRepo(_DbContext);
			}
		}
		public ISearchRepo ISearchRepo
		{
			get
			{
				return _ISearchRepo = _ISearchRepo ?? new SearchRepo(_DbContext);
			}
		}
	}
}
