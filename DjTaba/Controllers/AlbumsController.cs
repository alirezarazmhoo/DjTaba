﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using DjTaba.Models;
using DjTaba.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using DjTaba.Models.ViewModel;

namespace DjTaba.Controllers
{
    public class AlbumsController : Controller
    {

        private IUnitOfWorkRepo _unitofwork;
        public AlbumsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            try
            {
                var albums = await _unitofwork.IAlbumRepo.GetAllAlbumsAsync(); 
                return View(PaginatedList<Album>.CreateAsync(albums.AsQueryable(), pageNumber ?? 1, 3));
            }
            catch (Exception)
            {
                return Content("Something is Wrong");
            }
        }
        public IActionResult  Create()
        {
            return View();
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
            catch (Exception)
            {
                return Json(new { response = false, responseText = "Faild To Get Genres Data" });
            }
        }


    }
}