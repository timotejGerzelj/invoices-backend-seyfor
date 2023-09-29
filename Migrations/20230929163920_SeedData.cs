using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApiProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        private readonly Random _random = new Random();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert 10 Article records
            for (int i = 1; i <= 10; i++)
            {
                migrationBuilder.Sql($"INSERT INTO articles_table (name, price) VALUES ('Article{i}', 10.00)");
            }

            // Insert 2 Organisation records
            migrationBuilder.Sql("INSERT INTO organisation_table (name, description) VALUES ('Organisation1', 'Description 1')");

            // Insert 1000 Client records
            for (int i = 1; i <= 1000; i++)
            {
                migrationBuilder.Sql($"INSERT INTO client_table (name, address) VALUES ('Client{i}', 'Address {i}')");
            }

            // Create Invoice records with associated LineItems
            for (int i = 1; i <= 1000; i++)
            {
                // Set a random client_id between 1 and 10
                int randomClientId = _random.Next(1, 11);

                migrationBuilder.Sql($"INSERT INTO invoice_table (date_of_creation, price, org_id, client_id) VALUES ('2023-09-22', 100.00, 1, 1)");
                
                // Add 10 LineItem records for each Invoice with unique article_id
                for (int j = 1; j <= 5; j++)
                {
                    migrationBuilder.Sql($"INSERT INTO line_items_table (quantity, invoice_id, article_id) VALUES (1, {i}, {j})");
                }
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
