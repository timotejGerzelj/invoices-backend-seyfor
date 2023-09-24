using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    org_id = table.Column<int>(type: "int", nullable: false),
                    stranka_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racuni_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_racuni_table_organisation_table_org_id",
                        column: x => x.org_id,
                        principalTable: "organisation_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_racuni_table_stranka_table_stranka_id",
                        column: x => x.stranka_id,
                        principalTable: "stranka_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "line_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    article_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_line_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_line_items_artikli_table_article_id",
                        column: x => x.article_id,
                        principalTable: "artikli_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_line_items_racuni_table_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "racuni_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_line_items_article_id",
                table: "line_items",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_items_invoice_id",
                table: "line_items",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_racuni_table_org_id",
                table: "racuni_table",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_racuni_table_stranka_id",
                table: "racuni_table",
                column: "stranka_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "line_items");

            migrationBuilder.DropTable(
                name: "artikli_table");

            migrationBuilder.DropTable(
                name: "racuni_table");

            migrationBuilder.DropTable(
                name: "organisation_table");

            migrationBuilder.DropTable(
                name: "stranka_table");
        }
    }
}
