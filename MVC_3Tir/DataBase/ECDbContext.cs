using Microsoft.EntityFrameworkCore;
using MVC_3Tir.Models;

namespace MVC_3Tir.DataBase;

public class ECDbContext : DbContext
{
    public ECDbContext(DbContextOptions<ECDbContext> options) : base(options)
    {
    }
    public DbSet<Product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(e => e.Price)
            .HasColumnType("decimal(18,2)");
    }

}