using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<DjTaba.Models.Artist> Artists { get; set; }
		public DbSet<Models.ArtistImages> ArtistImages { get; set; }
		public DbSet<Models.Genre> Genres { get; set; }
		public DbSet<Models.Music> Musics { get; set; }
		public DbSet<Models.MusicFiles> MusicFiles { get; set; }
		public DbSet<Models.ArtistToMusic> ArtistToMusic { get; set; }
	}
}
