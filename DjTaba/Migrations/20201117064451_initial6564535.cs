using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial6564535 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pudcasts_Genres_GenreId",
                table: "Pudcasts");

            migrationBuilder.DropIndex(
                name: "IX_Pudcasts_GenreId",
                table: "Pudcasts");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Pudcasts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Pudcasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pudcasts_GenreId",
                table: "Pudcasts",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pudcasts_Genres_GenreId",
                table: "Pudcasts",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
