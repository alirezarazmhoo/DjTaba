using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using DjTaba.Models;
using DjTaba.Models.ViewModel;
using DjTaba.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers
{
    public class GenresController : Controller
    {
        private IUnitOfWorkRepo _unitofwork;
        public GenresController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            bool shouldsearch = false;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    shouldsearch = true;
                }
                int pageSize = 3;
                var genres = shouldsearch == false ? await _unitofwork.IGenreRepo.GetAllGenresAsync() 
                    : await _unitofwork.IGenreRepo.GetGenreWithDetailsAsync(searchString);
                return View(PaginatedList<Genre>.CreateAsync(genres.AsQueryable(), pageNumber ?? 1, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Some Things Is Wrong !");
            }
        }
        [HttpPost]
        public async Task<JsonResult> Register(Genre genre, int? GenreId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = "Required Fields Are Empty !" });
                }
                else
                {                  
                    if (GenreId != null)
                    {
                        genre.Id = GenreId.Value;
                    }
                    _unitofwork.IGenreRepo.CreateOrUpdateGenre(genre);
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
        public async Task<JsonResult> Remove(int GenreId)
        {
            try
            {
                var Genre = await _unitofwork.IGenreRepo.GetGenreByIdAsync(GenreId);
                if (Genre == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                _unitofwork.IGenreRepo.DeleteGenre(Genre);
                await _unitofwork.SaveAsync();
                return Json(new { success = true, responseText = "Operation Completed !" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        [HttpPost]
        public async Task<JsonResult> GenreInfo(int ItemId)
        {
            try
            {
                var Genre = await _unitofwork.IGenreRepo.GetGenreByIdAsync(ItemId);
                if (Genre == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "Name", value = Genre.Name });   
                edit.Add(new EditViewModels() { key = "GenreId", value = Genre.Id.ToString() });
                var artistImages = await _unitofwork.IArtistRepo.GetArtistPicture(Genre.Id);
  
                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

    }
}