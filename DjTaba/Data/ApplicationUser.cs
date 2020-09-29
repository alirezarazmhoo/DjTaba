using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DjTaba.Data
{
	public class ApplicationUser : IdentityUser
	{
		[PersonalData]
		[Column(TypeName = "nvarchar(100)")]
		public DateTime Birthday { get; set; }
	}
}
