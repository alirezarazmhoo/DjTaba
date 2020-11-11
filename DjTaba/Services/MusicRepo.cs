using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using DjTaba.Models.ViewModel;
using DjTaba.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async Task<IEnumerable<MusicChild>> GetSummaryMostViewedAllMusicAsync(int? pageNumber)
        {
            pageNumber = pageNumber == null ? 1 : pageNumber;
            List<MusicChild> musicChildren = new List<MusicChild>();
         
            foreach (var item in await _DbContext.Musics.Select(s => new
            { s.Id, s.Name, s.ArtistToMusics,s.Views , s.PictureMusicUrlThumbNail }).OrderByDescending(s => s.Views)
                .Skip((pageNumber.Value - 1) * 10).Take(10).ToListAsync())
            {
                musicChildren.Add(new MusicChild()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.PictureMusicUrlThumbNail,
                    Artists = item.ArtistToMusics
                     
                });
            }
            return musicChildren;
        }
        public async Task<IEnumerable<Music>> GetNewstMusicsAsync()
        {
            return await FindAll(s => s.MusicFiles).Include(s => s.MusicFiles).Include(s => s.Genre).Include(s => s.ArtistToMusics)
              .OrderByDescending(s => s.CreateDate)
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
        public void  CreateOrUpdateMusic(Music music, IFormFile Musicfile, IFormFile[] OtherFiles, string[] ArtistsId , IFormFile pictiremusic)
        {
            string[] _ArtistId = new string[] { };
           List<ArtistToMusic>  toMusics = new List<ArtistToMusic>();
            try
            {
                if (music.Id == 0)
                {
                    if (Musicfile != null && Musicfile.Length > 1)
                    {
                        var fileName = Path.GetFileName(Musicfile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Audio", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            Musicfile.CopyTo(fileStream);
                        }
                        music.MusicUrl = "/Upload/Music/Audio/" + fileName;
                    }
                    if (pictiremusic != null && pictiremusic.Length > 1)
                    {
                        Stream stream = pictiremusic.OpenReadStream();
                        Image ThumbnailImage = ResizeImage.GetReducedImage(150, 150, stream);
                        var fileName = Path.GetFileName(pictiremusic.FileName);
                        var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Cover\ThumbNail", fileName); 
                        ThumbnailImage.Save(filePath2);
                        music.PictureMusicUrlThumbNail = "/Upload/Music/Cover/ThumbNail/" + fileName; 
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Cover\MainImage", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {                          
                            pictiremusic.CopyTo(fileStream);
                        }
                        music.PictureMusicUrl = "/Upload/Music/Cover/MainImage/" + fileName;
                    }
                    _DbContext.Musics.Add(music);
                    _DbContext.SaveChanges();
                    if (ArtistsId.Length > 0)
                    {
                        _ArtistId = ArtistsId[0].Split(',');

                        foreach (var item in _ArtistId)
                        {
                            int _id = Int32.Parse(item);
                            var _artistname = _DbContext.Artists.FirstOrDefault(s => s.Id == _id).FullName;
                            toMusics.Add(new ArtistToMusic() { ArtistId = Convert.ToInt32(item), MusicId = music.Id, Name = _artistname });
                        }

                        _DbContext.ArtistToMusic.AddRange(toMusics);

                    }
                    if (OtherFiles != null && OtherFiles.Count() > 0)
                    {
                        foreach (var item in OtherFiles)
                        {
                            var fileName = Path.GetFileName(item.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Files", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                item.CopyTo(stream);
                                _DbContext.MusicFiles.Add(new MusicFiles()
                                {
                                    FileUrl = "/Upload/Music/Files/" + fileName,
                                    MusicId = music.Id,
                                    Type = FileType.Picture
                                });
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
                         
                            File.Delete($"wwwroot/Upload/Music/Audio/{music.MusicUrl}");
                        }
                        var fileName = Path.GetFileName(Musicfile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Audio", fileName);

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
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload\Music\Files", fileName);
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
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task DeleteMusic(Music music)
        {
            var MusicItem =await GetMusicByIdAsync(music.Id);

            if (!string.IsNullOrEmpty(MusicItem.MusicUrl))
            {
             File.Delete($"wwwroot/{music.MusicUrl}");
            }

            if(MusicItem.MusicFiles.Count > 0)
            {
                foreach (var item in MusicItem.MusicFiles)
                {
                    File.Delete($"wwwroot/{item.FileUrl}");
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


        public async Task AddViewToMusic(int id, string address)
        {
            Music MusicItem = await _DbContext.Musics.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(MusicItem is null)
            {
                throw new Exception();

            }


            ClientToMusic _clientToMusic = new ClientToMusic();
            if (_clientToMusic != null)
            {
                if (await _DbContext.ClientToMusic.AnyAsync(s => s.MusicId == id && s.Ip == address) == false)
                {
                    _clientToMusic.Ip = address;
                    _clientToMusic.MusicId = id;
                    _DbContext.ClientToMusic.Add(_clientToMusic);
                    MusicItem.Views += 1;
                    await _DbContext.SaveChangesAsync();
                }
            }
        }

    }
}
