using Microsoft.EntityFrameworkCore.Migrations;

namespace Saidality.Migrations
{
    public partial class update_stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Pharmcys_PharmacyId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_PharmacyId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "PharmcyID",
                table: "Stocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PharmcyID",
                table: "Stocks",
                column: "PharmcyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Pharmcys_PharmcyID",
                table: "Stocks",
                column: "PharmcyID",
                principalTable: "Pharmcys",
                principalColumn: "PharmcyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Pharmcys_PharmcyID",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_PharmcyID",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "PharmcyID",
                table: "Stocks");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PharmacyId",
                table: "Stocks",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Pharmcys_PharmacyId",
                table: "Stocks",
                column: "PharmacyId",
                principalTable: "Pharmcys",
                principalColumn: "PharmcyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
