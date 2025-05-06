using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_787888 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasvuruYonlendirs_Basvurus_Basvuru_Id",
                table: "BasvuruYonlendirs");

            migrationBuilder.DropForeignKey(
                name: "FK_BasvuruYonlendirs_Personels_Personel_Id",
                table: "BasvuruYonlendirs");

            migrationBuilder.AlterColumn<int>(
                name: "Personel_Id",
                table: "BasvuruYonlendirs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Basvuru_Id",
                table: "BasvuruYonlendirs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BasvuruYonlendirs_Basvurus_Basvuru_Id",
                table: "BasvuruYonlendirs",
                column: "Basvuru_Id",
                principalTable: "Basvurus",
                principalColumn: "Basvuru_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasvuruYonlendirs_Personels_Personel_Id",
                table: "BasvuruYonlendirs",
                column: "Personel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasvuruYonlendirs_Basvurus_Basvuru_Id",
                table: "BasvuruYonlendirs");

            migrationBuilder.DropForeignKey(
                name: "FK_BasvuruYonlendirs_Personels_Personel_Id",
                table: "BasvuruYonlendirs");

            migrationBuilder.AlterColumn<int>(
                name: "Personel_Id",
                table: "BasvuruYonlendirs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Basvuru_Id",
                table: "BasvuruYonlendirs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasvuruYonlendirs_Basvurus_Basvuru_Id",
                table: "BasvuruYonlendirs",
                column: "Basvuru_Id",
                principalTable: "Basvurus",
                principalColumn: "Basvuru_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasvuruYonlendirs_Personels_Personel_Id",
                table: "BasvuruYonlendirs",
                column: "Personel_Id",
                principalTable: "Personels",
                principalColumn: "Personel_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
