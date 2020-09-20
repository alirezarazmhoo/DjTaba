using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Data.Migrations
{
    public partial class Music : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusicId",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Lyric = table.Column<string>(nullable: true),
                    Arrangement = table.Column<string>(nullable: true),
                    CoverArt = table.Column<string>(nullable: true),
                    PhotoCreator = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    MusicKeys = table.Column<string>(nullable: true),
                    AbutMusic = table.Column<string>(nullable: true),
                    SongText = table.Column<string>(nullable: true),
                    MusicUrl = table.Column<string>(nullable: true),
                    RelaseDate = table.Column<DateTime>(nullable: false),
                    MixDate = table.Column<DateTime>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Quality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicId = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFiles_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_MusicId",
                table: "Artists",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFiles_MusicId",
                table: "MusicFiles",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_GenreId",
                table: "Musics",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Musics_MusicId",
                table: "Artists",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Musics_MusicId",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "MusicFiles");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Artists_MusicId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "MusicId",
                table: "Artists");
        }
    }
}
