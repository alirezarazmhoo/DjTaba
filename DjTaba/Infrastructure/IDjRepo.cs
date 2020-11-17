using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
	public interface IDjRepo
	{
        Task<IEnumerable<Dj>> GetAllDjsAsync();
        Task<Dj> GetDjsByIdAsync(int ownerId);
        Task<IEnumerable<Dj>> GetDjsWithDetailsAsync(string txtsearch);
        void CreateOrUpdateDj(Dj artist, IFormFile[] file);
        Task DeleteDj(Dj owner);
        Task<IEnumerable<DjImages>> GetDjPicture(int artistId);
        Task<DjImages> GetDjPictureByIdAsync(int FileId);
        void DeleteDjPicture(DjImages file);
    }
}
