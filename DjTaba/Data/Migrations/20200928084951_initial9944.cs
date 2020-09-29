using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Data.Migrations
{
    public partial class initial9944 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayListId",
                table: "Musics",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    MusicsCount = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    View = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PlayListId",
                table: "Musics",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_GenreId",
                table: "PlayLists",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_PlayLists_PlayListId",
                table: "Musics",
                column: "PlayListId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_PlayLists_PlayListId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropIndex(
                name: "IX_Musics_PlayListId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "Musics");
        }
    }
}
