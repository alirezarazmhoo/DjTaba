using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
namespace DjTaba.Infrastructure
{
	public interface ITicketRepo
	{
		Task Add(Ticket ticket);
		Task<IEnumerable<Ticket>> GetAllTicketsAsync();
	}
}
