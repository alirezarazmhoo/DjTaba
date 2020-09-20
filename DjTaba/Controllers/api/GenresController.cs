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
    }
}