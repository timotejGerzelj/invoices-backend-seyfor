using InvoiceApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApiProject.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {}

    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Client> Clients {get; set;} = null!;
    public DbSet<Article> Articles { get; set;} = null!;
    public DbSet<Organisation> Organisations { get; set;} = null!;
    public DbSet<LineItem> LineItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Invoice>()
        .HasOne(r => r.Client)
        .WithMany()
        .HasForeignKey(r => r.ClientId);
    
    modelBuilder.Entity<Invoice>()
        .HasOne(r => r.Organisation)
        .WithMany()
        .HasForeignKey(r => r.OrgId);
    
    modelBuilder.Entity<Invoice>()
        .HasMany(r => r.LineItems)  // Racun has many LineItems
        .WithOne(li => li.Invoice)  // LineItem belongs to one Racun
        .HasForeignKey(li => li.InvoiceId);  // Foreign key on LineItem referencing Racun
        }

}