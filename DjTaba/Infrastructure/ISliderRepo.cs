using DjTaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
   public interface ISliderRepo
	{
		Task<IEnumerable<Slider>> GetAllSlidersAsync();
	}
}
