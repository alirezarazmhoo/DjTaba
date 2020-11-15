using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Migrations
{
    public partial class initial54545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genres_GenreId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_GenreId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GenreToAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreToAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreToAlbums_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreToAlbums_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreToAlbums_AlbumId",
                table: "GenreToAlbums",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreToAlbums_GenreId",
                table: "GenreToAlbums",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreToAlbums");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreId",
                table: "Albums",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genres_GenreId",
                table: "Albums",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
