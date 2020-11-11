using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Services
{
	public class ArtistRepo : RepositoryBase<Artist>, IArtistRepo
	{
        List<Artist> Artists = new List<Artist>();
        public ArtistRepo(ApplicationDbContext DbContext)
	    : base(DbContext)
		{
            _DbContext = DbContext;
		}
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await FindAll(s=>s.ArtistImages)
              .OrderByDescending(s => s.Id)
              .ToListAsync();
        }
        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {
            return await FindByCondition(s => s.Id.Equals(artistId)).Include(s=>s.ArtistImages)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Artist>> GetArtistWithDetailsAsync(string txtsearch)
        {
            return await FindByCondition(s => s.FullName.Contains(txtsearch))
                .ToListAsync();
        }
        public void CreateOrUpdateArtist(Artist artist , IFormFile[] file)
        {
            if(artist.Id == 0)
            {

            _DbContext.Artists.Add(artist);
                _DbContext.SaveChanges();
            if (file != null && file.Count() > 0)
            {

                foreach (var item in file)
                {
                    var fileName = Path.GetFileName(item.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\ImageArtist", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                        _DbContext.ArtistImages.Add(new ArtistImages() { ImageUrl = "/Upload/ImageArtist/"+ fileName, ArtistId = artist.Id });
                    }
                }
            }
            }
            else
            {
                Update(artist);
                if (file != null && file.Count() > 0)
                {
                    foreach (var item in file)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\ImageArtist", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                            _DbContext.ArtistImages.Add(new ArtistImages() { ImageUrl = "/Upload/ImageArtist/" + fileName, ArtistId = artist.Id });
                        }
                    }
                }
            }
        }
        public async Task DeleteArtist(Artist owner)
        {
            var ArtistItem =await  GetArtistByIdAsync(owner.Id);

            if (ArtistItem.ArtistImages.Count > 0)
            {
                foreach (var item in ArtistItem.ArtistImages)
                {
                    File.Delete($"wwwroot/{item.ImageUrl}");
                }
            }
            Delete(owner);
        }
        public async Task<IEnumerable<ArtistImages>> GetArtistPicture(int artistId)
        {
           var items = await _DbContext.ArtistImages.Where(s => s.ArtistId == artistId).ToListAsync();
           return  items;
        }
        public async Task<ArtistImages> GetArtistPictureByIdAsync(int FileId)
        {
         return await _DbContext.ArtistImages.Where(s => s.Id == FileId).FirstOrDefaultAsync();

        }
        public  void DeleteArtistPicture(ArtistImages file)
        {
            if (!string.IsNullOrEmpty(file.ImageUrl))
            {
                File.Delete($"wwwroot/{file.ImageUrl}");
            }
            _DbContext.ArtistImages.Remove(file);
        }
  
    }
}
