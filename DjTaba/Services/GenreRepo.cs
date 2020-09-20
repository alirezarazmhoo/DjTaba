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
	public class GenreRepo : RepositoryBase<Genre>, IGenreRepo
	{
     public GenreRepo(ApplicationDbContext DbContext)
	 : base(DbContext)
		{
			_DbContext = DbContext;
		}

		public async Task<IEnumerable<Genre>> GetAllGenresAsync()
		{
			return await FindAll(null)
			  .OrderByDescending(s => s.Id)
			  .ToListAsync();
		}
		public async Task<IEnumerable<Genre>> GetGenreWithDetailsAsync(string txtsearch)
		{
			    return await FindByCondition(s => s.Name.Contains(txtsearch))
				.ToListAsync();
		}
		public async Task<Genre> GetGenreByIdAsync(int GenreId)
		{
			return await FindByCondition(s => s.Id.Equals(GenreId))
				.FirstOrDefaultAsync();
		}
        public void CreateOrUpdateGenre(Genre genre)
        {
            if (genre.Id == 0)
            {
                _DbContext.Genres.Add(genre);
                _DbContext.SaveChanges();
            }
            else
            {
                Update(genre);
            }
        }
		public void DeleteGenre(Genre genre)
		{
			Delete(genre);
		}
	}
}
