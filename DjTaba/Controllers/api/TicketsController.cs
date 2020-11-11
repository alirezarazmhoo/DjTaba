using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DjTaba.Models;
using DjTaba.Models.ViewModel;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private IUnitOfWorkRepo _unitofwork;
        WebApiResponse response = new WebApiResponse();

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
                response.Message = "Your ticket has been sumbited";
                return Ok(response);
            }
            catch (Exception)
            {
                response.Message = "Unfortunately ticket not sumbited ! ";
                return BadRequest(response);
            }

        }



    }
}