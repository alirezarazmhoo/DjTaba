using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjTaba.Data.Migrations
{
    public partial class initial6545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ArtistImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ArtistImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ArtistImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ArtistImages",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
