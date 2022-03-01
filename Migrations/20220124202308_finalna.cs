using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement21A2.Migrations
{
    public partial class finalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id_klienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id_klienta);
                });

            migrationBuilder.CreateTable(
                name: "LoginViewModel",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginViewModel", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    Klasa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.Klasa);
                });

            migrationBuilder.CreateTable(
                name: "RegisterViewModels",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModels", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id_auta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klasa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rocznik = table.Column<int>(type: "int", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Silnik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id_auta);
                    table.ForeignKey(
                        name: "FK_Car_Prizes_Klasa",
                        column: x => x.Klasa,
                        principalTable: "Prizes",
                        principalColumn: "Klasa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CopyCars",
                columns: table => new
                {
                    Nr_rej = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Id_auta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyCars", x => x.Nr_rej);
                    table.ForeignKey(
                        name: "FK_CopyCars_Car_Id_auta",
                        column: x => x.Id_auta,
                        principalTable: "Car",
                        principalColumn: "Id_auta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id_wynajmu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_klienta = table.Column<int>(type: "int", nullable: false),
                    Nr_rej = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Data_od = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_do = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id_wynajmu);
                    table.ForeignKey(
                        name: "FK_Rents_Clients_Id_klienta",
                        column: x => x.Id_klienta,
                        principalTable: "Clients",
                        principalColumn: "Id_klienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_CopyCars_Nr_rej",
                        column: x => x.Nr_rej,
                        principalTable: "CopyCars",
                        principalColumn: "Nr_rej",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Klasa",
                table: "Car",
                column: "Klasa");

            migrationBuilder.CreateIndex(
                name: "IX_CopyCars_Id_auta",
                table: "CopyCars",
                column: "Id_auta");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_Id_klienta",
                table: "Rents",
                column: "Id_klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_Nr_rej",
                table: "Rents",
                column: "Nr_rej");

            var sql = @"
            CREATE OR ALTER VIEW [dbo].[samochody_wszystkie] AS
                SELECT se.Nr_rej AS Nr_rej, s.marka AS Marka, s.model AS Model,
s.rocznik AS Rocznik, s.klasa AS Klasa
                 FROM CopyCars se, Car  s 
    WHERE se.id_auta=s.id_auta 
ORDER BY se.nr_rej offset 0 rows ";


            migrationBuilder.Sql(sql);

            var sql1 = @"
            CREATE OR ALTER VIEW [dbo].[wypozyczenia_wszystkie] AS
            SELECT cl.nazwisko AS Nazwisko, cl.imie AS Imie, c.Marka AS Marka, c.Model AS Model, ABS(DATEDIFF(Day, r.Data_od, r.Data_do) * p.Cena) As Cena
                FROM Clients  cl, Rents r, CopyCars  cc, Car c, Prizes p
   WHERE cl.id_klienta = r.id_klienta AND r.nr_rej = cc.nr_rej AND p.Klasa = c.Klasa and
    cc.id_auta = c.id_auta
ORDER BY cl.nazwisko offset 0 rows ";

            migrationBuilder.Sql(sql1);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW wypozyczenia_wszystkie");
            migrationBuilder.Sql(@"DROP VIEW wypozyczenia_wszystkie");
            migrationBuilder.DropTable(
                name: "LoginViewModel");

            migrationBuilder.DropTable(
                name: "RegisterViewModels");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CopyCars");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Prizes");
        }
    }
}
