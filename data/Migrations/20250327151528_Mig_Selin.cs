using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_Selin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basvurus_Ilans_Ilan_Id",
                table: "Basvurus");

            migrationBuilder.DropForeignKey(
                name: "FK_Basvurus_Personels_Personel_Id",
                table: "Basvurus");

            migrationBuilder.AlterColumn<int>(
                name: "Personel_Id",
                table: "Basvurus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ilan_Id",
                table: "Basvurus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basvurus_Ilans_Ilan_Id",
                table: "Basvurus",
                column: "Ilan_Id",
                principalTable: "Ilans",
                principalColumn: "Ilan_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basvurus_Personels_Personel_Id",
                table: "Basvurus",
                column: "Personel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basvurus_Ilans_Ilan_Id",
                table: "Basvurus");

            migrationBuilder.DropForeignKey(
                name: "FK_Basvurus_Personels_Personel_Id",
                table: "Basvurus");

            migrationBuilder.AlterColumn<int>(
                name: "Personel_Id",
                table: "Basvurus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Ilan_Id",
                table: "Basvurus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Basvurus_Ilans_Ilan_Id",
                table: "Basvurus",
                column: "Ilan_Id",
                principalTable: "Ilans",
                principalColumn: "Ilan_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Basvurus_Personels_Personel_Id",
                table: "Basvurus",
                column: "Personel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id");
        }
    }
}
