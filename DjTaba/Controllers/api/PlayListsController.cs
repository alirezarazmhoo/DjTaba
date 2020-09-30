using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DjTaba.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        private readonly IActionContextAccessor _accessor;
        public PlayListsController(IUnitOfWorkRepo unitOfWork , IActionContextAccessor accessor)
        {
            _unitofwork = unitOfWork;
            _accessor = accessor;
        }
        [Route("GetAll")]
        public async Task<ActionResult> GetAll(int? pageNumber)
        {
            try
            {
                return Ok(await _unitofwork.IPlayListRepo.GetSummaryAllPlayListAsync(pageNumber));
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
                var Item = await _unitofwork.IPlayListRepo.GetPlaylistByIdAsync(Id);
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
        [Route("GetNewests")]
        public async Task<ActionResult> GetNewests(int? pageNumber)
        {
            try
            {
                return Ok(await _unitofwork.IPlayListRepo.GetAllNewstPlayListAsync(pageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetMostView")]
        public async Task<ActionResult> GetMostView(int? pageNumber)
        {
            try
            {
             return Ok(await _unitofwork.IPlayListRepo.GetAllMostViewedPlayListAsync(pageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("AddView")]
        public async Task<ActionResult> AddView(int Id , long DeviceId)
        {
            try
            {       
                await _unitofwork.IPlayListRepo.AddViewToPlayList(Id, DeviceId.ToString());
                return Ok("Every Thing is OK !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}