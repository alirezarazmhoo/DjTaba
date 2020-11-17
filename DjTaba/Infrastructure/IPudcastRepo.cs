using DjTaba.Models;
using DjTaba.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
 public	interface IPudcastRepo
	{
		Task<IEnumerable<Pudcast>> GetAllPudcastAsync();
		Task<IEnumerable<PudcastChild>> GetAllNewstPudcastAsync(int? pageNumber);
		Task<IEnumerable<PudcastChild>> GetAllMostViewedPudcastAsync(int? pageNumber);
		Task<PudcastAndMusic> GetPudcastByIdAsync(int Id);
		Task<IEnumerable<PudcastChild>> GetSummaryAllPudcastAsync(int? pageNumber);
		Task<IEnumerable<GetByGenreId>> GetPudcastByGenreIdAsync(int GenreId); 
		Task AddViewToPudcast(int id, string address);
	}

}
