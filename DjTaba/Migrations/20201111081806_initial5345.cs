using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial5345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistToAlbums_Artists_ArtistId",
                table: "ArtistToAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicToAlbums_Musics_MusicId",
                table: "MusicToAlbums");

            migrationBuilder.DropIndex(
                name: "IX_MusicToAlbums_MusicId",
                table: "MusicToAlbums");

            migrationBuilder.DropIndex(
                name: "IX_ArtistToAlbums_ArtistId",
                table: "ArtistToAlbums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MusicToAlbums_MusicId",
                table: "MusicToAlbums",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistToAlbums_ArtistId",
                table: "ArtistToAlbums",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistToAlbums_Artists_ArtistId",
                table: "ArtistToAlbums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicToAlbums_Musics_MusicId",
                table: "MusicToAlbums",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
