using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nettlesnook.Migrations
{
    public partial class ImageTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDesc",
                table: "BlogImages");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "BlogImages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagesID",
                table: "BlogImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltText = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages",
                column: "ImagesID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Images_ImagesID",
                table: "BlogImages",
                column: "ImagesID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Images_ImagesID",
                table: "BlogImages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_ImagesID",
                table: "BlogImages");

            migrationBuilder.DropColumn(
                name: "ImagesID",
                table: "BlogImages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ImageDesc",
                table: "BlogImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "BlogImages",
                nullable: true);
        }
    }
}
