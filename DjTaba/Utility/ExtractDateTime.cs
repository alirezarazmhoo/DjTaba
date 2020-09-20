using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Utility
{
	public class ExtractDateTime
	{
		public static string ExtractDate(DateTime date)
		{
			var year = date.Year;
			var month = date.Month.ToString("00");
			var day = date.Day.ToString("00");
			return string.Format("{0}-{1}-{2}", year, month, day);
		}
		}
}
