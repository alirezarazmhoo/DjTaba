using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using DjTaba.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Services
{
	public class AlbumRepo : RepositoryBase<Album>, IAlbumRepo
	{
		public AlbumRepo(ApplicationDbContext DbContext)
         : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
		{
			return await FindAll(null).Include(s => s.Genre).Include(s=>s.ArtistToAlbums).Include(s=>s.MusicToAlbums)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}
		public async Task<IEnumerable<Album>> GetAllNewstsAlbumsAsync()
		{
			return await FindAll(null).Include(s => s.Genre).Include(s => s.ArtistToAlbums).Include(s => s.MusicToAlbums)
			  .OrderByDescending(s => s.PublishedDate)
			  .ToListAsync();
		}
		public async Task<IEnumerable<Album>> GetAllMostViewedAlbumsAsync()
		{
			return await FindAll(null).Include(s => s.Genre).Include(s => s.ArtistToAlbums).Include(s => s.MusicToAlbums).OrderByDescending(s => s.View).Take(10)
	       .ToListAsync();
		}
		public async Task<AlbumAndDetailsViewModel> GetAlbumByIdAsync(int Id)
		{
			AlbumAndDetailsViewModel albumAndDetailsViewMode = new AlbumAndDetailsViewModel();
			Album albumitem = await _DbContext.Albums.Include(s=>s.Genre).Where(s => s.Id == Id).FirstOrDefaultAsync();
			List<MusicToAlbum> musicToAlbums = await _DbContext.MusicToAlbums.Include(s=>s.Music).Where(s=>s.AlbumId == Id).ToListAsync();
			List<ArtistToAlbum>  artistToAlbums = await _DbContext.ArtistToAlbums.Include(s => s.Artist).Where(s => s.AlbumId == Id).ToListAsync();
			List<ImagesToAlbum> imagesToAlbums = await _DbContext.ImagesToAlbums.Where(s => s.AlbumId == Id).ToListAsync();
			if (albumitem is null)
			{
				 throw new Exception();
			}
			albumAndDetailsViewMode.Album = albumitem;
			albumAndDetailsViewMode.Musics = musicToAlbums.ToList();
			albumAndDetailsViewMode.Artists = artistToAlbums.ToList();
			albumAndDetailsViewMode.Images = imagesToAlbums.ToList();
			return albumAndDetailsViewMode;
		}
		public async Task AddViewToAlbum(int id, string address)
		{
			Album albumItem = await _DbContext.Albums.Where(s => s.Id == id).FirstOrDefaultAsync();
			ClientToAlbum _clientToAlbum = new ClientToAlbum();
			if (albumItem != null)
			{
				if (await _DbContext.ClientToAlbums.AnyAsync(s => s.AlbumId == id && s.Ip == address) == false)
				{
					_clientToAlbum.Ip = address;
					_clientToAlbum.AlbumId = id;
					_DbContext.ClientToAlbums.Add(_clientToAlbum);
					albumItem.View += 1;
					await _DbContext.SaveChangesAsync();
				}
			}
		}



	}
}
