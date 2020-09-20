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
	}
}
