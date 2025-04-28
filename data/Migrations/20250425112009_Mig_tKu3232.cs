using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_tKu3232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegerlendirmeBelges_Personels_Perspnel_Id",
                table: "DegerlendirmeBelges");

            migrationBuilder.RenameColumn(
                name: "Perspnel_Id",
                table: "DegerlendirmeBelges",
                newName: "Personel_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DegerlendirmeBelges_Perspnel_Id",
                table: "DegerlendirmeBelges",
                newName: "IX_DegerlendirmeBelges_Personel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DegerlendirmeBelges_Personels_Personel_Id",
                table: "DegerlendirmeBelges",
                column: "Personel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegerlendirmeBelges_Personels_Personel_Id",
                table: "DegerlendirmeBelges");

            migrationBuilder.RenameColumn(
                name: "Personel_Id",
                table: "DegerlendirmeBelges",
                newName: "Perspnel_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DegerlendirmeBelges_Personel_Id",
                table: "DegerlendirmeBelges",
                newName: "IX_DegerlendirmeBelges_Perspnel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DegerlendirmeBelges_Personels_Perspnel_Id",
                table: "DegerlendirmeBelges",
                column: "Perspnel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
