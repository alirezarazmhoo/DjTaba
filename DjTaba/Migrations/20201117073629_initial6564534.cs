using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial6564534 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GenreToPudcast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GenreToPlaylists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GenreToAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GenreToPudcast");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GenreToPlaylists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GenreToAlbums");
        }
    }
}
