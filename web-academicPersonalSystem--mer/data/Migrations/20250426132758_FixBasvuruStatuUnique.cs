using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class FixBasvuruStatuUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.DropIndex(
				name: "IX_Basvurus_BasvuruStatu_Id",
				table: "Basvurus");

			migrationBuilder.CreateIndex(
				name: "IX_Basvurus_BasvuruStatu_Id",
				table: "Basvurus",
				column: "BasvuruStatu_Id");
			migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "Ilans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropIndex(
				name: "IX_Basvurus_BasvuruStatu_Id",
				table: "Basvurus");

			migrationBuilder.CreateIndex(
				name: "IX_Basvurus_BasvuruStatu_Id",
				table: "Basvurus",
				column: "BasvuruStatu_Id",
				unique: true);
			migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "Ilans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
