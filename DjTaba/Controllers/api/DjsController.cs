using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using DjTaba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DjsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        public DjsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _unitofwork.IDjRepo.GetAllDjsAsync());
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
                Dj Item = await _unitofwork.IDjRepo.GetDjsByIdAsync(Id);
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