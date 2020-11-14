using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial62354 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_Musics_MusicId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_MusicId",
                table: "Sliders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sliders_MusicId",
                table: "Sliders",
                column: "MusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_Musics_MusicId",
                table: "Sliders",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
