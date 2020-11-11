using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Data;
using DjTaba.Infrastructure;
using DjTaba.Models;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Services
{
	public class ComingsoonRepo : RepositoryBase<ComingSoon>, IComingsoonRepo
	{
		public ComingsoonRepo(ApplicationDbContext DbContext)
        : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<ComingSoon>> GetAllComingSoonsAsync()
		{
			return await FindAll(null)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}


	}
}
