using DjTaba.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
 public	interface ISearchRepo
	{
		Task<SearchByEveryThingViewModel> SearchByEveryThing(string txtsearch , int? pageNumber);
	}
}
