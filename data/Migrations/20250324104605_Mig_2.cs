using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ilans",
                columns: table => new
                {
                    Ilan_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilans", x => x.Ilan_Id);
                });

            migrationBuilder.CreateTable(
                name: "Katsayis",
                columns: table => new
                {
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanSayi = table.Column<int>(type: "int", nullable: false),
                    Katsayisi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katsayis", x => x.Katsayi_Id);
                });

            migrationBuilder.CreateTable(
                name: "Puanlamas",
                columns: table => new
                {
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puanlamas", x => x.Puanlama_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvans",
                columns: table => new
                {
                    Unvan_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvans", x => x.Unvan_Id);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Personel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TC = table.Column<int>(type: "int", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Unvan_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Personel_Id);
                    table.ForeignKey(
                        name: "FK_Personels_Unvans_Unvan_Id",
                        column: x => x.Unvan_Id,
                        principalTable: "Unvans",
                        principalColumn: "Unvan_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArastirmaProjesis",
                columns: table => new
                {
                    ArastirmaProjesi_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: true),
                    KurumIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArastirmaProjesis", x => x.ArastirmaProjesi_Id);
                    table.ForeignKey(
                        name: "FK_ArastirmaProjesis_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArastirmaProjesis_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArastirmaProjesis_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atifs",
                columns: table => new
                {
                    Atif_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtifSayi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atifs", x => x.Atif_Id);
                    table.ForeignKey(
                        name: "FK_Atifs_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atifs_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atifs_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basvurus",
                columns: table => new
                {
                    Basvuru_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statu = table.Column<int>(type: "int", nullable: false),
                    Ilan_Id = table.Column<int>(type: "int", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurus", x => x.Basvuru_Id);
                    table.ForeignKey(
                        name: "FK_Basvurus_Ilans_Ilan_Id",
                        column: x => x.Ilan_Id,
                        principalTable: "Ilans",
                        principalColumn: "Ilan_Id");
                    table.ForeignKey(
                        name: "FK_Basvurus_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id");
                });

            migrationBuilder.CreateTable(
                name: "BilimselToplantis",
                columns: table => new
                {
                    BilimselToplanti_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BildiriIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KonferansIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapildigiYer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SayfaSayi = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    YazarSayi = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<float>(type: "real", nullable: false),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilimselToplantis", x => x.BilimselToplanti_Id);
                    table.ForeignKey(
                        name: "FK_BilimselToplantis_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BilimselToplantis_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BilimselToplantis_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Editorluks",
                columns: table => new
                {
                    Editorluk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sayi = table.Column<int>(type: "int", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorluks", x => x.Editorluk_Id);
                    table.ForeignKey(
                        name: "FK_Editorluks_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Editorluks_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Editorluks_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EoFaaliyetleris",
                columns: table => new
                {
                    EoFaaliyetleri_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donem = table.Column<int>(type: "int", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EoFaaliyetleris", x => x.EoFaaliyetleri_Id);
                    table.ForeignKey(
                        name: "FK_EoFaaliyetleris_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EoFaaliyetleris_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EoFaaliyetleris_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gorevs",
                columns: table => new
                {
                    Gorev_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<bool>(type: "bit", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevs", x => x.Gorev_Id);
                    table.ForeignKey(
                        name: "FK_Gorevs_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gorevs_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gorevs_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitaps",
                columns: table => new
                {
                    Kitap_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinevi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaskiSayi = table.Column<int>(type: "int", nullable: true),
                    YayimYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    YazarSayi = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaps", x => x.Kitap_Id);
                    table.ForeignKey(
                        name: "FK_Kitaps_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaps_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaps_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Konservatuvars",
                columns: table => new
                {
                    Konservatuvar_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaaliyetIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konservatuvars", x => x.Konservatuvar_Id);
                    table.ForeignKey(
                        name: "FK_Konservatuvars_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konservatuvars_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konservatuvars_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Makales",
                columns: table => new
                {
                    Makale_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DergiIsim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiltNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SayfaSayi = table.Column<int>(type: "int", nullable: false),
                    BasimYili = table.Column<int>(type: "int", nullable: false),
                    YazarSayi = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<double>(type: "float", nullable: false),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makales", x => x.Makale_Id);
                    table.ForeignKey(
                        name: "FK_Makales_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makales_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makales_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oduls",
                columns: table => new
                {
                    Odul_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KurumIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oduls", x => x.Odul_Id);
                    table.ForeignKey(
                        name: "FK_Oduls_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oduls_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oduls_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patents",
                columns: table => new
                {
                    Patent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patents", x => x.Patent_Id);
                    table.ForeignKey(
                        name: "FK_Patents_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patents_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patents_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personel_Roles",
                columns: table => new
                {
                    Personel_Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel_Roles", x => x.Personel_Role_Id);
                    table.ForeignKey(
                        name: "FK_Personel_Roles_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_Roles_Rols_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rols",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TezYoneticiligis",
                columns: table => new
                {
                    TezYoneticiligi_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enstutu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<double>(type: "float", nullable: true),
                    Personel_Id = table.Column<int>(type: "int", nullable: false),
                    Puanlama_Id = table.Column<int>(type: "int", nullable: false),
                    Katsayi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TezYoneticiligis", x => x.TezYoneticiligi_Id);
                    table.ForeignKey(
                        name: "FK_TezYoneticiligis_Katsayis_Katsayi_Id",
                        column: x => x.Katsayi_Id,
                        principalTable: "Katsayis",
                        principalColumn: "Katsayi_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TezYoneticiligis_Personels_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "Personels",
                        principalColumn: "Personel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TezYoneticiligis_Puanlamas_Puanlama_Id",
                        column: x => x.Puanlama_Id,
                        principalTable: "Puanlamas",
                        principalColumn: "Puanlama_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Belges",
                columns: table => new
                {
                    Belge_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basvuru_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belges", x => x.Belge_Id);
                    table.ForeignKey(
                        name: "FK_Belges_Basvurus_Basvuru_Id",
                        column: x => x.Basvuru_Id,
                        principalTable: "Basvurus",
                        principalColumn: "Basvuru_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArastirmaProjesis_Katsayi_Id",
                table: "ArastirmaProjesis",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArastirmaProjesis_Personel_Id",
                table: "ArastirmaProjesis",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArastirmaProjesis_Puanlama_Id",
                table: "ArastirmaProjesis",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atifs_Katsayi_Id",
                table: "Atifs",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atifs_Personel_Id",
                table: "Atifs",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atifs_Puanlama_Id",
                table: "Atifs",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_Ilan_Id",
                table: "Basvurus",
                column: "Ilan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_Personel_Id",
                table: "Basvurus",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Belges_Basvuru_Id",
                table: "Belges",
                column: "Basvuru_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BilimselToplantis_Katsayi_Id",
                table: "BilimselToplantis",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BilimselToplantis_Personel_Id",
                table: "BilimselToplantis",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BilimselToplantis_Puanlama_Id",
                table: "BilimselToplantis",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Editorluks_Katsayi_Id",
                table: "Editorluks",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Editorluks_Personel_Id",
                table: "Editorluks",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Editorluks_Puanlama_Id",
                table: "Editorluks",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EoFaaliyetleris_Katsayi_Id",
                table: "EoFaaliyetleris",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EoFaaliyetleris_Personel_Id",
                table: "EoFaaliyetleris",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EoFaaliyetleris_Puanlama_Id",
                table: "EoFaaliyetleris",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevs_Katsayi_Id",
                table: "Gorevs",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevs_Personel_Id",
                table: "Gorevs",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevs_Puanlama_Id",
                table: "Gorevs",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_Katsayi_Id",
                table: "Kitaps",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_Personel_Id",
                table: "Kitaps",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_Puanlama_Id",
                table: "Kitaps",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Konservatuvars_Katsayi_Id",
                table: "Konservatuvars",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Konservatuvars_Personel_Id",
                table: "Konservatuvars",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Konservatuvars_Puanlama_Id",
                table: "Konservatuvars",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Makales_Katsayi_Id",
                table: "Makales",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Makales_Personel_Id",
                table: "Makales",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Makales_Puanlama_Id",
                table: "Makales",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Oduls_Katsayi_Id",
                table: "Oduls",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Oduls_Personel_Id",
                table: "Oduls",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Oduls_Puanlama_Id",
                table: "Oduls",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patents_Katsayi_Id",
                table: "Patents",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patents_Personel_Id",
                table: "Patents",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patents_Puanlama_Id",
                table: "Patents",
                column: "Puanlama_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_Roles_Personel_Id",
                table: "Personel_Roles",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_Roles_Rol_Id",
                table: "Personel_Roles",
                column: "Rol_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_Unvan_Id",
                table: "Personels",
                column: "Unvan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TezYoneticiligis_Katsayi_Id",
                table: "TezYoneticiligis",
                column: "Katsayi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TezYoneticiligis_Personel_Id",
                table: "TezYoneticiligis",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TezYoneticiligis_Puanlama_Id",
                table: "TezYoneticiligis",
                column: "Puanlama_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArastirmaProjesis");

            migrationBuilder.DropTable(
                name: "Atifs");

            migrationBuilder.DropTable(
                name: "Belges");

            migrationBuilder.DropTable(
                name: "BilimselToplantis");

            migrationBuilder.DropTable(
                name: "Editorluks");

            migrationBuilder.DropTable(
                name: "EoFaaliyetleris");

            migrationBuilder.DropTable(
                name: "Gorevs");

            migrationBuilder.DropTable(
                name: "Kitaps");

            migrationBuilder.DropTable(
                name: "Konservatuvars");

            migrationBuilder.DropTable(
                name: "Makales");

            migrationBuilder.DropTable(
                name: "Oduls");

            migrationBuilder.DropTable(
                name: "Patents");

            migrationBuilder.DropTable(
                name: "Personel_Roles");

            migrationBuilder.DropTable(
                name: "TezYoneticiligis");

            migrationBuilder.DropTable(
                name: "Basvurus");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Katsayis");

            migrationBuilder.DropTable(
                name: "Puanlamas");

            migrationBuilder.DropTable(
                name: "Ilans");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Unvans");
        }
    }
}
