using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DjTaba.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
		public DbSet<Models.Video> Videos { get; set; }
		public DbSet<Models.PlayList> PlayLists { get; set; }
		public DbSet<Models.ClientToPlayList> ClientToPlayLists { get; set; }
		public DbSet<Models.Album> Albums { get; set; }
		public DbSet<Models.ArtistToAlbum> ArtistToAlbums { get; set; }
		public DbSet<Models.ImagesToAlbum> ImagesToAlbums { get; set; }
		public DbSet<Models.MusicToAlbum> MusicToAlbums { get; set; }
		public DbSet<Models.ClientToAlbum> ClientToAlbums { get; set; }
		public DbSet<Models.PlayListToMusic> PlayListToMusics { get; set; }
		public DbSet<Models.Ticket> Tickets { get; set; }
		public DbSet<Models.Slider> Sliders { get; set; }
		public DbSet<Models.ClientToMusic> ClientToMusic { get; set; }
		public DbSet<Models.ComingSoon>  ComingSoons { get; set; }
		public DbSet<Models.MyExepction> MyExepctions { get; set; }
		public DbSet<Models.GenreToAlbum> GenreToAlbums { get; set; }
	}
}
