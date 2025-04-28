using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_8993232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegerlendirmeBelges",
                columns: table => new
                {
                    DegerlendirmeBelge_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perspnel_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegerlendirmeBelges", x => x.DegerlendirmeBelge_Id);
                    table.ForeignKey(
                        name: "FK_DegerlendirmeBelges_Personels_Perspnel_Id",
                        column: x => x.Perspnel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegerlendirmeBelges_Perspnel_Id",
                table: "DegerlendirmeBelges",
                column: "Perspnel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegerlendirmeBelges");
        }
    }
}
