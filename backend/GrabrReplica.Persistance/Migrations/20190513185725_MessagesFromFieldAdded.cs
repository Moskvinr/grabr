using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabrReplica.Persistance.Migrations
{
    public partial class MessagesFromFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageFrom",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageFrom",
                table: "Messages");
        }
    }
}
