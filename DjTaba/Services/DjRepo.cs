using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Services
{
	public class DjRepo  : RepositoryBase<Dj>, IDjRepo
	{

        List<Dj> Djs = new List<Dj>();
        public DjRepo(ApplicationDbContext DbContext)
        : base(DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<IEnumerable<Dj>> GetAllDjsAsync()
        {
            return await FindAll(s => s.DjImages)
              .OrderByDescending(s => s.Id)
              .ToListAsync();
        }
        public async Task<Dj> GetDjsByIdAsync(int artistId)
        {
            return await FindByCondition(s => s.Id.Equals(artistId)).Include(s => s.DjImages)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Dj>> GetDjsWithDetailsAsync(string txtsearch)
        {
            return await FindByCondition(s => s.FullName.Contains(txtsearch))
                .ToListAsync();
        }
        public void CreateOrUpdateDj(Dj dj, IFormFile[] file)
        {
            if (dj.Id == 0)
            {

                _DbContext.Djs.Add(dj);
                _DbContext.SaveChanges();
                if (file != null && file.Count() > 0)
                {

                    foreach (var item in file)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Dj\MainImage", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                            _DbContext.DjImages.Add(new DjImages() { ImageUrl = "/Upload/Dj/MainImage/" + fileName, DjId = dj.Id  });
                        }
                    }
                }
            }
            else
            {
                Update(dj);
                if (file != null && file.Count() > 0)
                {
                    foreach (var item in file)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Dj\MainImage", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                            _DbContext.DjImages.Add(new DjImages() { ImageUrl = "/Upload/Dj/MainImage/" + fileName, DjId = dj.Id });
                        }
                    }
                }
            }
        }
        public async Task DeleteDj(Dj owner)
        {
            var DjItem = await GetDjsByIdAsync(owner.Id);
            if (DjItem.DjImages.Count > 0)
            {
                foreach (var item in DjItem.DjImages)
                {
                    File.Delete($"wwwroot/{item.ImageUrl}");
                }
            }
            Delete(owner);
        }
        public async Task<IEnumerable<DjImages>> GetDjPicture(int djId)
        {
            var items = await _DbContext.DjImages.Where(s => s.DjId == djId).ToListAsync();
            return items;
        }
        public async Task<DjImages> GetDjPictureByIdAsync(int FileId)
        {
            return await _DbContext.DjImages.Where(s => s.Id == FileId).FirstOrDefaultAsync();

        }
        public void DeleteDjPicture(DjImages file)
        {
            if (!string.IsNullOrEmpty(file.ImageUrl))
            {
                File.Delete($"wwwroot/{file.ImageUrl}");
            }
            _DbContext.DjImages.Remove(file);
        }
         



    }
}
