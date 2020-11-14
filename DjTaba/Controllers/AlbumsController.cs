using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using DjTaba.Models;
using DjTaba.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                return Content("Some Things Is Wrong !");
            }
        }

        public async Task<IActionResult>  Create()
        {
            ViewBag.Genre = new SelectList(await _unitofwork.IGenreRepo.GetAllGenresAsync(), "Id", "Name");
            return View();
        }



    }
}