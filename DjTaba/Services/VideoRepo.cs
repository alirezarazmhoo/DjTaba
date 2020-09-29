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
	public class VideoRepo : RepositoryBase<Video>, IVideoRepo
	{
     public VideoRepo(ApplicationDbContext DbContext)
     : base(DbContext)
		{
			_DbContext = DbContext;
		}
		public async Task<IEnumerable<Video>> GetAllVideosAsync()
		{
			return await FindAll(null)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}
		public async Task<IEnumerable<Video>> GetAllNewstsVideosAsync()
		{
			return await FindAll(null)
			  .OrderByDescending(s => s.CreateDate)
			  .ToListAsync();
		}
		public async Task<Video> GetVideoByIdAsync(int Id)
		{
			return await FindByCondition(s => s.Id.Equals(Id))
				.FirstOrDefaultAsync();
		}
	}
}
