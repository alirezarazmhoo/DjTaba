using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        private readonly IActionContextAccessor _accessor;
        public AlbumsController(IUnitOfWorkRepo unitOfWork, IActionContextAccessor accessor)
        {
            _unitofwork = unitOfWork;
            _accessor = accessor;
        }
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _unitofwork.IAlbumRepo.GetAllAlbumsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            try
            {
                var Item = await _unitofwork.IAlbumRepo.GetAlbumByIdAsync(Id);
                if (Item is null )
                {
                    return BadRequest($"The Id By {Id} Is Not Found !");
                }
                else
                {
                    return Ok(Item);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetNewests")]
        public async Task<ActionResult> GetNewests()
        {
            try
            {
                return Ok(await _unitofwork.IAlbumRepo.GetAllNewstsAlbumsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetMostView")]
        public async Task<ActionResult> GetMostView()
        {
            try
            {
                return Ok(await _unitofwork.IAlbumRepo.GetAllMostViewedAlbumsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("AddView")]
        public async Task<ActionResult> AddView(int Id)
        {
            try
            {
                var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                await _unitofwork.IAlbumRepo.AddViewToAlbum(Id, ip);
                return Ok("Every Thing is OK !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetByGenreId")]
        public async Task<ActionResult> GetByGenreId(int Id)
        {
            try
            {
                var Item = await _unitofwork.IAlbumRepo.GetAlbumByGenreIdAsync(Id);
                if (Item is null)
                {
                    return BadRequest($"The Id By {Id} Is Not Found !");
                }
                else
                {
                    return Ok(Item);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}