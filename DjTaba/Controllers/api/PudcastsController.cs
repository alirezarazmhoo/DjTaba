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
    public class PudcastsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        public PudcastsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Route("GetAll")]
        public async Task<ActionResult> GetAll(int? pageNumber)
        {
            try
            {
                return Ok(await _unitofwork.IPudcastRepo.GetSummaryAllPudcastAsync(pageNumber));
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
                var Item = await _unitofwork.IPudcastRepo.GetPudcastByIdAsync(Id);
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
                return Ok(await _unitofwork.IPudcastRepo.GetAllNewstPudcastAsync(pageNumber));
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
                return Ok(await _unitofwork.IPudcastRepo.GetAllMostViewedPudcastAsync(pageNumber));
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
                await _unitofwork.IPudcastRepo.AddViewToPudcast(Id, DeviceId.ToString());
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
                var Item = await _unitofwork.IPudcastRepo.GetPudcastByGenreIdAsync(Id);
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