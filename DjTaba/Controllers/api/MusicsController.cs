using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;

        public MusicsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _unitofwork.IMusicRepo.GetAllMusicsAsync());
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
                var MusicItem = await _unitofwork.IMusicRepo.GetMusicByIdAsync(Id);
                if (MusicItem is null)
                {
                    return BadRequest($"The Id By {Id} Is Not Found !");
                }
                else
                {
                    return Ok(MusicItem);
                }
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
                var MusicItem = await _unitofwork.IMusicRepo.GetMusicByGenreIdAsync(Id);
                if (MusicItem is null)
                {
                    return BadRequest($"The Id By {Id} Is Not Found !");
                }
                else
                {
                    return Ok(MusicItem);
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
                return Ok(await _unitofwork.IMusicRepo.GetNewstMusicsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetMostViewd")]
        public async Task<ActionResult> GetMostViewd(int? pageNumber)
        {
            try
            {
                return Ok(await _unitofwork.IMusicRepo.GetSummaryMostViewedAllMusicAsync(pageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("AddView")]
        public async Task<ActionResult> AddView(int Id, long DeviceId)
        {
            try
            {
                await _unitofwork.IMusicRepo.AddViewToMusic(Id, DeviceId.ToString());
                return Ok("Every Thing is OK !");
            }
            catch (Exception)
            {
                return BadRequest($"The Music Id By {DeviceId} Does Not Found !");
            }

        }
    }
}