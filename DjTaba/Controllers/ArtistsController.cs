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
using Microsoft.Extensions.Logging;


namespace DjTaba.Controllers
{
    public class ArtistsController : Controller
    {
        Artist Artist = new Artist();
        private IUnitOfWorkRepo _unitofwork;

        public ArtistsController(IUnitOfWorkRepo unitOfWork)
        {  
            _unitofwork = unitOfWork;
        }
        public async Task< IActionResult> Index(string searchString , int? pageNumber)
        {
            bool shouldsearch = false;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                  shouldsearch = true;
                }
             int pageSize =3;
             var artists = shouldsearch == false ? await  _unitofwork.IArtistRepo.GetAllArtistsAsync() : await _unitofwork.IArtistRepo.GetArtistWithDetailsAsync(searchString);
            return View(PaginatedList<Artist>.CreateAsync(artists.AsQueryable(), pageNumber ?? 1, pageSize));
            }
            catch(Exception ex)
            {
              
                return Content("Some Things Is Wrong !");
            }
        }
        [HttpPost]
        public async Task< JsonResult> Register(IFormFile[] file, Artist artist , int? ArtistId)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, responseText = "Required Fields Are Empty !" });
            }
            else
            {
                for (int i = 0; i < file.Count(); i++)
                {
                    if (!FormatChecker.CheckFormat(file[i]))
                    {
                        return Json(new { success = false, responseText = "Incorrect Image  Format !" });
                    }
                }
                     if(ArtistId != null)
                    {
                     artist.Id = ArtistId.Value;
                    }
                    _unitofwork.IArtistRepo.CreateOrUpdateArtist(artist , file);
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
        public async Task<JsonResult> Remove(int ArtistId)
        {
            try
            {
                var Artist = await _unitofwork.IArtistRepo.GetArtistByIdAsync(ArtistId);
                if (Artist == null)
                {
            
                    return Json(new { success = false, responseText = "Requset Faild !" });

                }

    
        
               await _unitofwork.IArtistRepo.DeleteArtist(Artist);
                await _unitofwork.SaveAsync();
                return Json(new { success = true, responseText = "Operation Completed !" });

            }
            catch (Exception ex)
            {
    
                return Json(new { success = false, responseText = "Requset Faild !" });
            }

        }
        
        public async Task<JsonResult> ArtistsInfo(int ItemId)
        {
            try
            {
                var Artist = await _unitofwork.IArtistRepo.GetArtistByIdAsync(ItemId);
                if (Artist == null)
                {
                
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                List<ArtistPictureViewModels> artistPictureViewModels = new List<ArtistPictureViewModels>();

                edit.Add(new EditViewModels() { key = "FullName", value = Artist.FullName });
                edit.Add(new EditViewModels() { key = "Biography", value = Artist.Biography });
                edit.Add(new EditViewModels() { key = "ArtistId", value = Artist.Id.ToString() });
                var artistImages =await _unitofwork.IArtistRepo.GetArtistPicture(Artist.Id);
                if(artistImages.Count() > 0 )
                {
                    foreach (var item in artistImages)
                    {
                        artistPictureViewModels.Add(new ArtistPictureViewModels()
                        { id = item.Id, url =item.ImageUrl});
                    }
                }
                return Json(new { success = true, listItem = edit.ToList() , artistfiles = artistPictureViewModels.ToList() });
            }
            catch (Exception)
            {
           
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAtristPicture(int FileId)
        {
            try
            {
             var file = await _unitofwork.IArtistRepo.GetArtistPictureByIdAsync(FileId);
             if(file is null)
             {
          
                 return Json(new { success = false, responseText = "Requset Faild !" });
             }
             _unitofwork.IArtistRepo.DeleteArtistPicture(file);
             await _unitofwork.SaveAsync();
             return Json(new { success = true, responseText = "Operation Completed !" });
            }
            catch (Exception ex)
            {
           
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

    }
}