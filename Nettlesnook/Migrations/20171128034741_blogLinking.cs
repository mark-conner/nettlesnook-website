using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nettlesnook.Migrations
{
    public partial class blogLinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogID",
                table: "BlogImages",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blog_BlogID",
                table: "BlogImages",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blog_BlogID",
                table: "BlogImages");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_BlogID",
                table: "BlogImages");
        }
    }
}
