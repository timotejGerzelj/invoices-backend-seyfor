using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class firstBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organisation_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_of_creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    org_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoice_table_client_table_client_id",
                        column: x => x.client_id,
                        principalTable: "client_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_table_organisation_table_org_id",
                        column: x => x.org_id,
                        principalTable: "organisation_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "line_items_table",
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
                    table.PrimaryKey("PK_line_items_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_line_items_table_articles_table_article_id",
                        column: x => x.article_id,
                        principalTable: "articles_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_line_items_table_invoice_table_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoice_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_table_client_id",
                table: "invoice_table",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_table_org_id",
                table: "invoice_table",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_items_table_article_id",
                table: "line_items_table",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_items_table_invoice_id",
                table: "line_items_table",
                column: "invoice_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "line_items_table");

            migrationBuilder.DropTable(
                name: "articles_table");

            migrationBuilder.DropTable(
                name: "invoice_table");

            migrationBuilder.DropTable(
                name: "client_table");

            migrationBuilder.DropTable(
                name: "organisation_table");
        }
    }
}
