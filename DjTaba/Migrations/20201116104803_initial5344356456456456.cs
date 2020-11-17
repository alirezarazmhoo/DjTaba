using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial5344356456456456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pudcasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    GenreId = table.Column<int>(nullable: true),
                    MusicsCount = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageUrlThumbNail = table.Column<string>(nullable: true),
                    View = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pudcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pudcasts_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientToPudcasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(nullable: true),
                    PudcastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientToPudcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientToPudcasts_Pudcasts_PudcastId",
                        column: x => x.PudcastId,
                        principalTable: "Pudcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PudcastToMusics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicId = table.Column<int>(nullable: true),
                    PudcastId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PudcastToMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PudcastToMusics_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PudcastToMusics_Pudcasts_PudcastId",
                        column: x => x.PudcastId,
                        principalTable: "Pudcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientToPudcasts_PudcastId",
                table: "ClientToPudcasts",
                column: "PudcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Pudcasts_GenreId",
                table: "Pudcasts",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PudcastToMusics_MusicId",
                table: "PudcastToMusics",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_PudcastToMusics_PudcastId",
                table: "PudcastToMusics",
                column: "PudcastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientToPudcasts");

            migrationBuilder.DropTable(
                name: "PudcastToMusics");

            migrationBuilder.DropTable(
                name: "Pudcasts");
        }
    }
}
