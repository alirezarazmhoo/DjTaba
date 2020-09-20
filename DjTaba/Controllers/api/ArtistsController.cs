using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using DjTaba.Models;

using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;

        public ArtistsController(IUnitOfWorkRepo unitOfWork)
        {

            _unitofwork = unitOfWork;
        }

        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _unitofwork.IArtistRepo.GetAllArtistsAsync());
            }
            catch (Exception ex)
            {          
                return BadRequest(ex.Message);
            }

        }
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                Artist artistItem = await _unitofwork.IArtistRepo.GetArtistByIdAsync(id); 
                if(artistItem is null)
                {
                    return BadRequest("ItemNotFound !");
                }
                else
                {

                return Ok(artistItem);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}