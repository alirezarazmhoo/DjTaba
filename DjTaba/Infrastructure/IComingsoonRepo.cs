using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Models;
namespace DjTaba.Infrastructure
{
  public interface IComingsoonRepo
	{
		Task<IEnumerable<ComingSoon>> GetAllComingSoonsAsync();
	}
}
