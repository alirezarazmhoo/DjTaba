using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using DjTaba.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Services
{
	public class MusicRepo : RepositoryBase<Music>, IMusicRepo
	{
		public MusicRepo(ApplicationDbContext DbContext)
	   : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<Music>> GetAllMusicsAsync()
		{
			return await FindAll(s => s.MusicFiles).Include(s=>s.MusicFiles).Include(s=>s.Genre).Include(s=>s.ArtistToMusics)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}
		public async Task<Music> GetMusicByIdAsync(int musicId)
		{
			return await FindByCondition(s => s.Id.Equals(musicId)).Include(s => s.MusicFiles).Include(s => s.ArtistToMusics)
                .FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<Music>> GetMusicWithDetailsAsync(string txtsearch)
		{
			return await FindByCondition(s => s.AbutMusic.Contains(txtsearch)
			|| s.Arrangement.Contains(txtsearch) || s.CoverArt.Contains(txtsearch)
			|| s.MusicKeys.Contains(txtsearch) || s.Name.Contains(txtsearch) || 
			s.PhotoCreator.Contains(txtsearch) )
				.ToListAsync();
		}
        public void  CreateOrUpdateMusic(Music music, IFormFile Musicfile, IFormFile[] OtherFiles, string[] ArtistsId)
        {
            string[] _ArtistId = new string[] { };
           List<ArtistToMusic>  toMusics = new List<ArtistToMusic>();
            if (music.Id == 0)
            {
                if (Musicfile != null && Musicfile.Length > 1)
                {
                    var fileName = Path.GetFileName(Musicfile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Musicfile.CopyTo(fileStream);

                    }

                    music.MusicUrl = fileName;
                }
                _DbContext.Musics.Add(music);
                _DbContext.SaveChanges();
                if(ArtistsId.Length > 0)
                {
                    _ArtistId = ArtistsId[0].Split(',');

                    foreach (var item in _ArtistId)
                    {
                        int _id = Int32.Parse(item);
                        var _artistname = _DbContext.Artists.FirstOrDefault(s => s.Id == _id).FullName; 
                        toMusics.Add(new ArtistToMusic() { ArtistId = Convert.ToInt32(item), MusicId = music.Id , Name = _artistname });
                    }

                    _DbContext.ArtistToMusic.AddRange(toMusics);

                }
                if (OtherFiles != null && OtherFiles.Count() > 0)
                {
                    foreach (var item in OtherFiles)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\MusicFiles", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(stream);       
                            _DbContext.MusicFiles.Add(new MusicFiles() { FileUrl = fileName , MusicId = music.Id ,
                            Type = FormatChecker.CheckFormat(item) == true ? FileType.Picture : 
                            FormatChecker.CheckVideoFormat(item) == true ? FileType.Video : FileType.Other});
                        }
                    }
                }
            }
            else
            {
                if (Musicfile != null && Musicfile.Length > 1)
                {
                    if (!String.IsNullOrEmpty(music.MusicUrl))
                    {
                        File.Delete($"wwwroot/Upload/Music/{music.MusicUrl}");
                    }
                   var fileName = Path.GetFileName(Musicfile.FileName);
                   var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music", fileName);

                   using (var fileStream = new FileStream(filePath, FileMode.Create))
                   {
                   Musicfile.CopyTo(fileStream);
                   }
                    music.MusicUrl = fileName;

                }
                if (OtherFiles != null && OtherFiles.Count() > 0)
                {
                    foreach (var item in OtherFiles)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\MusicFiles", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                            _DbContext.MusicFiles.Add(new MusicFiles()
                            {
                                FileUrl = fileName,
                                MusicId = music.Id,
                                Type = FormatChecker.CheckFormat(item) == true ? FileType.Picture : FileType.Other
                            });
                        }
                    }
                }
                    Update(music);
                }
        }
        public async Task DeleteMusic(Music music)
        {
            var MusicItem =await GetMusicByIdAsync(music.Id);

            if (!string.IsNullOrEmpty(MusicItem.MusicUrl))
            {
             File.Delete($"wwwroot/Upload/Music/{music.MusicUrl}");
            }

            if(MusicItem.MusicFiles.Count > 0)
            {
                foreach (var item in MusicItem.MusicFiles)
                {
                    File.Delete($"wwwroot/Upload/MusicFiles/{item.FileUrl}");
                }
            }
            Delete(music);
        }
        public void DeleteMusicFile(MusicFiles file)
        {
            if (!string.IsNullOrEmpty(file.FileUrl))
            {
                File.Delete($"wwwroot/Upload/MusicFiles/{file.FileUrl}");
            }
            _DbContext.MusicFiles.Remove(file);
        }
        public async Task<MusicFiles> GetMusicFileByIdAsync(int FileId)
        {
            return await _DbContext.MusicFiles.Where(s => s.Id == FileId).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<Music>> GetMusicByGenreIdAsync(int GenreId)
        {
            return await FindByCondition(s =>s.GenreId == GenreId)
            .ToListAsync();
        }
    }
}
