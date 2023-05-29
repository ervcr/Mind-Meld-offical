using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mind_Meld.Migrations
{
    public partial class DPtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SuppID",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Purch_Order_RequestID",
                table: "Purch_Order",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Purch_Order_SuppID",
                table: "Purch_Order",
                column: "SuppID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SuppID",
                table: "Product",
                column: "SuppID");

            migrationBuilder.CreateIndex(
                name: "IX_PR_DTL_ProdID",
                table: "PR_DTL",
                column: "ProdID");

            migrationBuilder.CreateIndex(
                name: "IX_PR_DTL_RequestID",
                table: "PR_DTL",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_PR_DTL_Product_ProdID",
                table: "PR_DTL",
                column: "ProdID",
                principalTable: "Product",
                principalColumn: "ProdID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PR_DTL_PurchRequest_RequestID",
                table: "PR_DTL",
                column: "RequestID",
                principalTable: "PurchRequest",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SuppID",
                table: "Product",
                column: "SuppID",
                principalTable: "Supplier",
                principalColumn: "SuppID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purch_Order_PurchRequest_RequestID",
                table: "Purch_Order",
                column: "RequestID",
                principalTable: "PurchRequest",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purch_Order_Supplier_SuppID",
                table: "Purch_Order",
                column: "SuppID",
                principalTable: "Supplier",
                principalColumn: "SuppID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PR_DTL_Product_ProdID",
                table: "PR_DTL");

            migrationBuilder.DropForeignKey(
                name: "FK_PR_DTL_PurchRequest_RequestID",
                table: "PR_DTL");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SuppID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Purch_Order_PurchRequest_RequestID",
                table: "Purch_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Purch_Order_Supplier_SuppID",
                table: "Purch_Order");

            migrationBuilder.DropIndex(
                name: "IX_Purch_Order_RequestID",
                table: "Purch_Order");

            migrationBuilder.DropIndex(
                name: "IX_Purch_Order_SuppID",
                table: "Purch_Order");

            migrationBuilder.DropIndex(
                name: "IX_Product_SuppID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PR_DTL_ProdID",
                table: "PR_DTL");

            migrationBuilder.DropIndex(
                name: "IX_PR_DTL_RequestID",
                table: "PR_DTL");

            migrationBuilder.AlterColumn<string>(
                name: "SuppID",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
