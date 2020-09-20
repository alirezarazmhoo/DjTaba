using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Data.Migrations
{
    public partial class initial1525 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArtistToMusic",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArtistToMusic");
        }
    }
}
