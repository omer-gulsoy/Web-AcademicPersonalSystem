using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statu",
                table: "Basvurus",
                newName: "BasvuruStatu_Id");

            migrationBuilder.CreateTable(
                name: "BasvuruStatus",
                columns: table => new
                {
                    BasvuruStatu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasvuruStatus", x => x.BasvuruStatu_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuruStatu_Id",
                table: "Basvurus",
                column: "BasvuruStatu_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basvurus_BasvuruStatus_BasvuruStatu_Id",
                table: "Basvurus",
                column: "BasvuruStatu_Id",
                principalTable: "BasvuruStatus",
                principalColumn: "BasvuruStatu_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basvurus_BasvuruStatus_BasvuruStatu_Id",
                table: "Basvurus");

            migrationBuilder.DropTable(
                name: "BasvuruStatus");

            migrationBuilder.DropIndex(
                name: "IX_Basvurus_BasvuruStatu_Id",
                table: "Basvurus");

            migrationBuilder.RenameColumn(
                name: "BasvuruStatu_Id",
                table: "Basvurus",
                newName: "Statu");
        }
    }
}
