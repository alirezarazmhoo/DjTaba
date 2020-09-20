using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using DjTaba.Models;
using DjTaba.Models.ViewModel;
using DjTaba.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers
{
    public class MusicsController : Controller
    {
        private IUnitOfWorkRepo _unitofwork;

        public MusicsController(IUnitOfWorkRepo unitOfWork)
        {

            _unitofwork = unitOfWork;
        }
        public async Task< IActionResult> Index(string searchString, int? pageNumber)
        {
            bool shouldsearch = false;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
             {
             shouldsearch = true;
             }
                int pageSize = 3;
                var Musics = shouldsearch == false ? await _unitofwork.IMusicRepo.GetAllMusicsAsync()
                    : await _unitofwork.IMusicRepo.GetMusicWithDetailsAsync(searchString);
                return View(PaginatedList<Music>.CreateAsync(Musics.AsQueryable(), pageNumber ?? 1, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Some Things Is Wrong !");
            }
        }

        [HttpPost]
        public async Task<JsonResult> Register(Music music,string[] ArtistsId, int? MusicId, IFormFile file, IFormFile[] musicfiles)
        {
            try
            {
                if (String.IsNullOrEmpty(music.Name) || file.Length ==0)
                {
                    return Json(new { success = false, responseText = "Required Fields Are Empty !" });
                }
                else
                {
                    if (MusicId != null)
                    {
                        music.Id = MusicId.Value;
                    }
                    if (!FormatChecker.CheckMusicFormat(file))
                    {
                        return Json(new { success = false, responseText = "Incorrect Music  Format !" });
                    }
                    _unitofwork.IMusicRepo.CreateOrUpdateMusic(music , file, musicfiles, ArtistsId);

                    await _unitofwork.SaveAsync();
                    return Json(new { success = true, responseText = "Operation Completed !" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Remove(int MusicId)
        {
            try
            {
                var Music = await _unitofwork.IMusicRepo.GetMusicByIdAsync(MusicId);
                if (Music == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                await _unitofwork.IMusicRepo.DeleteMusic(Music);
                await _unitofwork.SaveAsync();
                return Json(new { success = true, responseText = "Operation Completed !" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        public async Task<JsonResult> MusicInfo(int ItemId)
        {
            try
            {
                var Music = await _unitofwork.IMusicRepo.GetMusicByIdAsync(ItemId);
                if (Music == null)
                {
                 return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<MusicFilesViewModels> musicFiles = new List<MusicFilesViewModels>();
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "MusicId", value = Music.Id.ToString() });
                edit.Add(new EditViewModels() { key = "Name", value = Music.Name });
                edit.Add(new EditViewModels() { key = "Lyric", value = Music.Lyric});
                edit.Add(new EditViewModels() { key = "Arrangement", value = Music.Arrangement });
                edit.Add(new EditViewModels() { key = "CoverArt", value = Music.CoverArt });
                edit.Add(new EditViewModels() { key = "PhotoCreator", value = Music.PhotoCreator });
                edit.Add(new EditViewModels() { key = "ShortDescription", value = Music.ShortDescription });
                edit.Add(new EditViewModels() { key = "Link", value = Music.Link });
                edit.Add(new EditViewModels() { key = "Speed", value = Music.Speed });
                edit.Add(new EditViewModels() { key = "MusicKeys", value = Music.MusicKeys });
                edit.Add(new EditViewModels() { key = "AbutMusic", value = Music.AbutMusic });
                edit.Add(new EditViewModels() { key = "SongText", value = Music.SongText });
                edit.Add(new EditViewModels() { key = "SongText", value = Music.SongText });
                edit.Add(new EditViewModels() { key = "RelaseDate", value = ExtractDateTime.ExtractDate(Music.RelaseDate)});
                edit.Add(new EditViewModels() { key = "MixDate", value = ExtractDateTime.ExtractDate(Music.MixDate)});
                edit.Add(new EditViewModels() { key = "Size", value = Music.Size.ToString() });
                edit.Add(new EditViewModels() { key = "Quality", value = Music.Quality.ToString() });
                var MusicImages = Music.MusicFiles.ToList();
                if (MusicImages.Count() > 0)
                {
                    foreach (var item in MusicImages)
                    {
                          musicFiles.Add(new MusicFilesViewModels()
                          {
                          id = item.Id  , 
                          FileType = item.Type , 
                          target = "MusicFiles" , 
                          url = item.FileUrl,
                          specialtypefile = item.Type == FileType.Picture ? 
                          "Picture" : item.Type == FileType.Video ? "Video" :"Other"
                          });
                    }
                }
              musicFiles.Add(new MusicFilesViewModels() { id = 0, FileType = null, url =Music.MusicUrl, target = "MusicAudioFile" });
              return Json(new { success = true, listItem = edit.ToList(), files = musicFiles });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        [HttpPost]
        public async Task<JsonResult> RemoveMusicFile(int FileId)
        {
            try
            {
                var file = await _unitofwork.IMusicRepo.GetMusicFileByIdAsync(FileId);
                if (file is null)
                {

                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                _unitofwork.IMusicRepo.DeleteMusicFile(file);
                await _unitofwork.SaveAsync();
                return Json(new { success = true, responseText = "Operation Completed !" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

       [HttpGet]
        public async Task<JsonResult> LoadArtists()
        {
            List<ComboBoxViewModel> items = new List<ComboBoxViewModel>();
            try
            {        
                foreach (var item in await _unitofwork.IArtistRepo.GetAllArtistsAsync())
                {
                    items.Add(new ComboBoxViewModel() { id = item.Id, name = item.FullName });

                }
                return Json(new { success = true , list = items.ToList() });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Faild To Get Artists Data" });

            }
        }
    
        public async Task<JsonResult> LoadGenres()
        {
            List<ComboBoxViewModel> items = new List<ComboBoxViewModel>();

            try
            {
                foreach (var item in await _unitofwork.IGenreRepo.GetAllGenresAsync())
                {
                    items.Add(new ComboBoxViewModel() { id = item.Id, name = item.Name });

                }
                return Json(new { success = true, list = items.ToList() });
            }
            catch (Exception ex)
            {
                return Json(new { response = false, responseText = "Faild To Get Genres Data" });

            }
        }

    }
}