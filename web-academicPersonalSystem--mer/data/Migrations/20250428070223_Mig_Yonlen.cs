using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
	/// <inheritdoc />
	public partial class Mig_Yonlen : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "BasvuruYonlendirs",
				columns: table => new
				{
					BasvuruYonlendir_Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Basvuru_Id = table.Column<int>(type: "int", nullable: false),
					Personel_Id = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BasvuruYonlendirs", x => x.BasvuruYonlendir_Id);
					table.ForeignKey(
						name: "FK_BasvuruYonlendirs_Basvurus_Basvuru_Id",
						column: x => x.Basvuru_Id,
						principalTable: "Basvurus",
						principalColumn: "Basvuru_Id",
									onDelete: ReferentialAction.NoAction); // No cascade delete
					table.ForeignKey(
						name: "FK_BasvuruYonlendirs_Personels_Personel_Id",
						column: x => x.Personel_Id,
						principalTable: "Personels",
						principalColumn: "Personel_Id",
									onDelete: ReferentialAction.NoAction); // No cascade delete
				});

			migrationBuilder.CreateIndex(
				name: "IX_BasvuruYonlendirs_Basvuru_Id",
				table: "BasvuruYonlendirs",
				column: "Basvuru_Id");

			migrationBuilder.CreateIndex(
				name: "IX_BasvuruYonlendirs_Personel_Id",
				table: "BasvuruYonlendirs",
				column: "Personel_Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "BasvuruYonlendirs");
		}
	}
}
