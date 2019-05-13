using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabrReplica.Persistance.Migrations
{
    public partial class messageTimeFormatChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SentTime",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SentTime",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
