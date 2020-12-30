using Microsoft.EntityFrameworkCore.Migrations;

namespace SoforunuSec.Data.Migrations
{
    public partial class Tablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciAdi = table.Column<string>(nullable: true),
                    sifre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arabaMarka = table.Column<string>(nullable: true),
                    kmYakma = table.Column<float>(nullable: false),
                    yil = table.Column<int>(nullable: false),
                    koltukSayisi = table.Column<int>(nullable: false),
                    motorHacmi = table.Column<float>(nullable: false)
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
                    baslik = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    konum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizeUlasin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hakkimizda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(nullable: true),
                    fotograf = table.Column<string>(nullable: true),
                    aciklama = table.Column<string>(nullable: true)
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
                    adSoyad = table.Column<string>(nullable: true),
                    konu = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    telefonNo = table.Column<string>(nullable: true),
                    mesaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sofor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adSoyad = table.Column<string>(nullable: true),
                    yas = table.Column<int>(nullable: false),
                    kazaSayisi = table.Column<int>(nullable: false),
                    Cinsiyet = table.Column<int>(nullable: false),
                    Fotograf = table.Column<string>(nullable: true),
                    arabaId = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sofor_arabaId",
                table: "Sofor",
                column: "arabaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

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
        }
    }
}
