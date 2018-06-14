using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nettlesnook.Migrations
{
    public partial class UpdateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TimeStamp",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
