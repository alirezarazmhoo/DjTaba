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
    public class SearchsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        public SearchsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Route("Search")]
        public async Task<ActionResult> GetAll(string txtsearch)
        {
            try
            {
                return Ok(await _unitofwork.ISearchRepo.SearchByEveryThing(txtsearch));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}