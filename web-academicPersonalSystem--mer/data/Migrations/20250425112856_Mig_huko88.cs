using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
	/// <inheritdoc />
	public partial class Mig_huko88 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "Basvuru_Id",
				table: "DegerlendirmeBelges",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_DegerlendirmeBelges_Basvuru_Id",
				table: "DegerlendirmeBelges",
				column: "Basvuru_Id");

			// Foreign key ilişkisinin cascade delete yerine NoAction kullanılarak güncellenmesi
			migrationBuilder.AddForeignKey(
				name: "FK_DegerlendirmeBelges_Basvurus_Basvuru_Id",
				table: "DegerlendirmeBelges",
				column: "Basvuru_Id",
				principalTable: "Basvurus",
				principalColumn: "Basvuru_Id",
				onDelete: ReferentialAction.NoAction);  // Cascade yerine NoAction kullanıldı
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_DegerlendirmeBelges_Basvurus_Basvuru_Id",
				table: "DegerlendirmeBelges");

			migrationBuilder.DropIndex(
				name: "IX_DegerlendirmeBelges_Basvuru_Id",
				table: "DegerlendirmeBelges");

			migrationBuilder.DropColumn(
				name: "Basvuru_Id",
				table: "DegerlendirmeBelges");
		}
	}
}
