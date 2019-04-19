using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabrReplica.Persistance.Migrations
{
    public partial class ordersTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderById",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderById",
                table: "Orders",
                newName: "OrderByUserId");

            migrationBuilder.RenameColumn(
                name: "DeliveryManId",
                table: "Orders",
                newName: "DeliveryManUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderById",
                table: "Orders",
                newName: "IX_Orders_OrderByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryManId",
                table: "Orders",
                newName: "IX_Orders_DeliveryManUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryManUserId",
                table: "Orders",
                column: "DeliveryManUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderByUserId",
                table: "Orders",
                column: "OrderByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryManUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderByUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderByUserId",
                table: "Orders",
                newName: "OrderById");

            migrationBuilder.RenameColumn(
                name: "DeliveryManUserId",
                table: "Orders",
                newName: "DeliveryManId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderByUserId",
                table: "Orders",
                newName: "IX_Orders_OrderById");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryManUserId",
                table: "Orders",
                newName: "IX_Orders_DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderById",
                table: "Orders",
                column: "OrderById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
