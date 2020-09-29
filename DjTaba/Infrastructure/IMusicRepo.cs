using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
    public interface IMusicRepo
	{
        Task<IEnumerable<Music>> GetAllMusicsAsync();
        Task<Music> GetMusicByIdAsync(int musicId);
        Task<IEnumerable<Music>> GetMusicWithDetailsAsync(string txtsearch);
        void CreateOrUpdateMusic(Music music, IFormFile Musicfile, IFormFile[] OtherFiles , string[] ArtistsId , IFormFile pictiremusic);
        Task DeleteMusic(Music music);
        void DeleteMusicFile(MusicFiles file);
        Task<MusicFiles> GetMusicFileByIdAsync(int FileId);
        Task<IEnumerable<Music>> GetMusicByGenreIdAsync(int GenreId);
        Task<IEnumerable<Music>> GetNewstMusicsAsync();

    }
}
