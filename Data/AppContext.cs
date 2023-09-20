using InvoiceApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApiProject.Data;
public class InvoiceApiProjectContext : DbContext
{
    public InvoiceApiProjectContext(DbContextOptions<InvoiceApiProjectContext> options)
        : base(options)
    {}

    public DbSet<Racun> Racuni { get; set; } = null!;
    public DbSet<Stranka> Stranke {get;} = null!;
    public DbSet<Artikel> Artikli { get; } = null!;
    public DbSet<Organizacija> Organizacije { get; } = null!;
    public DbSet<RacunVrstica> LineItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Racun>()
        .HasOne(r => r.Stranka)
        .WithMany()
        .HasForeignKey(r => r.StrankaId);
    
    modelBuilder.Entity<Racun>()
        .HasOne(r => r.Organizacija)
        .WithMany()
        .HasForeignKey(r => r.OrgId);
    
    modelBuilder.Entity<Racun>()
        .HasMany(r => r.LineItems)  // Racun has many LineItems
        .WithOne(li => li.Racun)  // LineItem belongs to one Racun
        .HasForeignKey(li => li.RacunId);  // Foreign key on LineItem referencing Racun
        }

}