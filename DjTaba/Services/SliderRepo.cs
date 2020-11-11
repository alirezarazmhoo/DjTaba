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
	public class SliderRepo  : RepositoryBase<Slider>, ISliderRepo
	{
		public SliderRepo(ApplicationDbContext DbContext)
        : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<Slider>> GetAllSlidersAsync()
		{
			return await FindAll(null)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}
	}
}
