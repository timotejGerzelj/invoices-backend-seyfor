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
            .HasOne(r => r.Artikel)
            .WithMany()
            .HasForeignKey(r => r.ArtikelId);
        }

}