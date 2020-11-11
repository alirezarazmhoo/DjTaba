using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Models
{
	public class MyExepction
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		
		public string InnderExceptionMessage { get; set; }


	}
}
