using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial534435645543545435 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayLists_Genres_GenreId",
                table: "PlayLists");

            migrationBuilder.DropIndex(
                name: "IX_PlayLists_GenreId",
                table: "PlayLists");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "PlayLists");

            migrationBuilder.CreateTable(
                name: "GenreToPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    PlayListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreToPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreToPlaylists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreToPlaylists_PlayLists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreToPudcast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    PudcastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreToPudcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreToPudcast_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreToPudcast_Pudcasts_PudcastId",
                        column: x => x.PudcastId,
                        principalTable: "Pudcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreToPlaylists_GenreId",
                table: "GenreToPlaylists",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreToPlaylists_PlayListId",
                table: "GenreToPlaylists",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreToPudcast_GenreId",
                table: "GenreToPudcast",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreToPudcast_PudcastId",
                table: "GenreToPudcast",
                column: "PudcastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreToPlaylists");

            migrationBuilder.DropTable(
                name: "GenreToPudcast");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "PlayLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_GenreId",
                table: "PlayLists",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayLists_Genres_GenreId",
                table: "PlayLists",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
