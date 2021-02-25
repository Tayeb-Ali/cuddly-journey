using Microsoft.EntityFrameworkCore.Migrations;

namespace Saidality.Migrations
{
    public partial class update_pharmcy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmcys_Medicines_MedicineID",
                table: "Pharmcys");

            migrationBuilder.DropIndex(
                name: "IX_Pharmcys_MedicineID",
                table: "Pharmcys");

            migrationBuilder.DropColumn(
                name: "MedicineID",
                table: "Pharmcys");

            migrationBuilder.CreateTable(
                name: "MedicinePharmcy",
                columns: table => new
                {
                    MedicinesMedicineID = table.Column<int>(type: "int", nullable: false),
                    PharmciesPharmcyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePharmcy", x => new { x.MedicinesMedicineID, x.PharmciesPharmcyID });
                    table.ForeignKey(
                        name: "FK_MedicinePharmcy_Medicines_MedicinesMedicineID",
                        column: x => x.MedicinesMedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePharmcy_Pharmcys_PharmciesPharmcyID",
                        column: x => x.PharmciesPharmcyID,
                        principalTable: "Pharmcys",
                        principalColumn: "PharmcyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePharmcy_PharmciesPharmcyID",
                table: "MedicinePharmcy",
                column: "PharmciesPharmcyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinePharmcy");

            migrationBuilder.AddColumn<int>(
                name: "MedicineID",
                table: "Pharmcys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmcys_MedicineID",
                table: "Pharmcys",
                column: "MedicineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmcys_Medicines_MedicineID",
                table: "Pharmcys",
                column: "MedicineID",
                principalTable: "Medicines",
                principalColumn: "MedicineID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
