using DjTaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Infrastructure
{
	public interface IVideoRepo
	{
		Task<IEnumerable<Video>> GetAllVideosAsync();
		Task<IEnumerable<Video>> GetAllNewstsVideosAsync();
		Task<Video> GetVideoByIdAsync(int Id); 
	}
}
