using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nettlesnook.Migrations
{
    public partial class Images3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages");

            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BlogID",
                table: "Images",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages",
                column: "ImagesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Blog_BlogID",
                table: "Images",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Blog_BlogID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BlogID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages",
                column: "ImagesID",
                unique: true);
        }
    }
}
