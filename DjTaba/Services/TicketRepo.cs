using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Services
{
	public class TicketRepo : RepositoryBase<Ticket>, ITicketRepo
	{
		public TicketRepo(ApplicationDbContext DbContext)
		: base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task Add(Ticket ticket)
		{
		_DbContext.Tickets.Add(ticket);
		await _DbContext.SaveChangesAsync();
		} 
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
		{
		  return await FindAll(null)
		  .OrderByDescending(s => s.Id)
		  .ToListAsync();
		}

	}
	
		
}
