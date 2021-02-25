using Microsoft.EntityFrameworkCore.Migrations;

namespace Saidality.Migrations
{
    public partial class update_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locatons_LocatonID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "LocatonID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locatons_LocatonID",
                table: "Orders",
                column: "LocatonID",
                principalTable: "Locatons",
                principalColumn: "LocatonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locatons_LocatonID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "LocatonID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locatons_LocatonID",
                table: "Orders",
                column: "LocatonID",
                principalTable: "Locatons",
                principalColumn: "LocatonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
