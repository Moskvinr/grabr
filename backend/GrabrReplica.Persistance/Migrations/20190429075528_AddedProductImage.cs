using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabrReplica.Persistance.Migrations
{
    public partial class AddedProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Orders");
        }
    }
}
