using DjTaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
  public interface IGenreRepo
	{
		Task<IEnumerable<Genre>> GetAllGenresAsync();
		Task<Genre> GetGenreByIdAsync(int GenreId);
		void CreateOrUpdateGenre(Genre genre);
		void DeleteGenre(Genre genre);
		Task<IEnumerable<Genre>> GetGenreWithDetailsAsync(string txtsearch);
	}
}
