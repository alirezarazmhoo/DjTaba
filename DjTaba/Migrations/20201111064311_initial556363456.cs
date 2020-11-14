using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial556363456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicThumbNailPicture",
                table: "MusicToAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicThumbNailPicture",
                table: "MusicToAlbums");
        }
    }
}
