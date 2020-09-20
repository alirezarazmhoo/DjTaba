using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Data.Migrations
{
    public partial class initial534 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistToMusic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(nullable: false),
                    MusicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistToMusic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistToMusic_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistToMusic_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistToMusic_ArtistId",
                table: "ArtistToMusic",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistToMusic_MusicId",
                table: "ArtistToMusic",
                column: "MusicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistToMusic");
        }
    }
}
