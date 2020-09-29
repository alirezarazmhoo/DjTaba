using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DjTaba.Models;
namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        public TicketsController(IUnitOfWorkRepo unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Route("Add")]
        public async Task<ActionResult> Add(Ticket ticket)
        {
            try
            {
                await _unitofwork.ITicketRepo.Add(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}