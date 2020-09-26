using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using DjTaba.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        public GenresController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _unitofwork.IGenreRepo.GetAllGenresAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetByid")]
        [HttpGet]
        public async Task<ActionResult> GetByid(int Id)
        {
            try
            {
                var item = await _unitofwork.IGenreRepo.GetGenreByIdAsync(Id); 
                if(item is null)
                {
                    return BadRequest($"The Id By {Id} Is Not Found !");

                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}