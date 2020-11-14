using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial663625 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistPictureThumbNail",
                table: "ArtistToAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistPictureThumbNail",
                table: "ArtistToAlbums");
        }
    }
}
