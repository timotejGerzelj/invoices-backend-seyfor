using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrganisations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_line_items_table_articles_table_article_id",
                table: "line_items_table");

            migrationBuilder.DropIndex(
                name: "IX_line_items_table_article_id",
                table: "line_items_table");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_line_items_table_article_id",
                table: "line_items_table",
                column: "article_id");

            migrationBuilder.AddForeignKey(
                name: "FK_line_items_table_articles_table_article_id",
                table: "line_items_table",
                column: "article_id",
                principalTable: "articles_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
