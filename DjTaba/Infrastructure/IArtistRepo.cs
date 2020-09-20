using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
	public interface IArtistRepo :  IRepositoryBase<Artist>
	{
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int ownerId);
         Task<IEnumerable<Artist>> GetArtistWithDetailsAsync(string txtsearch);
        void CreateOrUpdateArtist(Artist artist , IFormFile[] file);
        void DeleteArtist(Artist artist);
         Task<IEnumerable<ArtistImages>> GetArtistPicture(int artistId);
        Task<ArtistImages> GetArtistPictureByIdAsync(int FileId);
        void DeleteArtistPicture(ArtistImages file);
    }
}
