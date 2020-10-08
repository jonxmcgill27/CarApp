using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarApp.Data.Migrations
{
    public partial class addedImagePropertyToEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Events",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");
        }
    }
}
