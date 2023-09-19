using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artikli_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artikli_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organisation_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stranka_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stranka_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "racuni_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_of_creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    znesek = table.Column<float>(type: "real", nullable: false),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    StrankaId = table.Column<int>(type: "int", nullable: false),
                    ArtikelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racuni_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_racuni_table_artikli_table_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "artikli_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_racuni_table_organisation_table_OrgId",
                        column: x => x.OrgId,
                        principalTable: "organisation_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_racuni_table_stranka_table_StrankaId",
                        column: x => x.StrankaId,
                        principalTable: "stranka_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_racuni_table_ArtikelId",
                table: "racuni_table",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_racuni_table_OrgId",
                table: "racuni_table",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_racuni_table_StrankaId",
                table: "racuni_table",
                column: "StrankaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "racuni_table");

            migrationBuilder.DropTable(
                name: "artikli_table");

            migrationBuilder.DropTable(
                name: "organisation_table");

            migrationBuilder.DropTable(
                name: "stranka_table");
        }
    }
}
