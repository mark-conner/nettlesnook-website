using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nettlesnook.Migrations
{
    public partial class Images5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages",
                column: "ImagesID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages",
                column: "ImagesID");
        }
    }
}
