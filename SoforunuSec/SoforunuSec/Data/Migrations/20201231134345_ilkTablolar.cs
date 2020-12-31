using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoforunuSec.Data.Migrations
{
    public partial class ilkTablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    modelYılı = table.Column<int>(nullable: true),
                    koltukSayisi = table.Column<int>(nullable: true),
                    kmYakit = table.Column<double>(nullable: true),
                    motorHacmi = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BizeUlasin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Konum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizeUlasin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dilAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hakkimizda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Fotograf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimizda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(nullable: true),
                    Konu = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    telefonNo = table.Column<string>(nullable: true),
                    Mesaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ulkeAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sehirAd = table.Column<string>(nullable: true),
                    ulkeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sehir_Ulke_ulkeId",
                        column: x => x.ulkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sofor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adSoyad = table.Column<string>(nullable: true),
                    dogumTarihi = table.Column<DateTime>(nullable: false),
                    kazaSayisi = table.Column<int>(nullable: true),
                    Cinsiyet = table.Column<int>(nullable: false),
                    Fotograf = table.Column<string>(nullable: true),
                    arabaId = table.Column<int>(nullable: true),
                    dilId = table.Column<int>(nullable: true),
                    ulkeId = table.Column<int>(nullable: true),
                    sehirId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sofor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sofor_Araba_arabaId",
                        column: x => x.arabaId,
                        principalTable: "Araba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sofor_Dil_dilId",
                        column: x => x.dilId,
                        principalTable: "Dil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sofor_Sehir_sehirId",
                        column: x => x.sehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sofor_Ulke_ulkeId",
                        column: x => x.ulkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sehir_ulkeId",
                table: "Sehir",
                column: "ulkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sofor_arabaId",
                table: "Sofor",
                column: "arabaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sofor_dilId",
                table: "Sofor",
                column: "dilId");

            migrationBuilder.CreateIndex(
                name: "IX_Sofor_sehirId",
                table: "Sofor",
                column: "sehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Sofor_ulkeId",
                table: "Sofor",
                column: "ulkeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BizeUlasin");

            migrationBuilder.DropTable(
                name: "Hakkimizda");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Sofor");

            migrationBuilder.DropTable(
                name: "Araba");

            migrationBuilder.DropTable(
                name: "Dil");

            migrationBuilder.DropTable(
                name: "Sehir");

            migrationBuilder.DropTable(
                name: "Ulke");
        }
    }
}
