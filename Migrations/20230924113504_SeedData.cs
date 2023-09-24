using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    // Insert 10 Artikel records
    for (int i = 1; i <= 10; i++)
    {
        migrationBuilder.Sql($"INSERT INTO artikli_table (ime, cena) VALUES ('Artikel{i}', 10.00)");
    }

    // Insert 2 Organizacija records
    migrationBuilder.Sql("INSERT INTO organisation_table (ime, opis) VALUES ('Organizacija1', 'Opis 1')");
    migrationBuilder.Sql("INSERT INTO organisation_table (ime, opis) VALUES ('Organizacija2', 'Opis 2')");

    // Insert 1000 Stranka records
    for (int i = 1; i <= 1000; i++)
    {
        migrationBuilder.Sql($"INSERT INTO stranka_table (ime, naslov) VALUES ('Stranka{i}', 'Naslov {i}')");
    }

    // Create Racun records with associated LineItems (RacunVrstica)
    for (int i = 1; i <= 1000; i++)
    {
        migrationBuilder.Sql($"INSERT INTO racuni_table (date_of_creation, znesek, org_id, stranka_id) VALUES ('2023-09-22', 100.00, 1, {i})");
        // Add 10 RacunVrstica records for each Racun
        for (int j = 1; j <= 10; j++)
        {
            migrationBuilder.Sql($"INSERT INTO line_items (quantity, invoice_id, article_id) VALUES (1, {i}, 1)");
        }
    }
}


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
