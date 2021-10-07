using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelsLayer.Models;

#nullable disable

namespace DataLayerDbContext.Models
{
  public partial class ShopDbContext : DbContext
  {
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Seasonal> Seasonals { get; set; }
    public virtual DbSet<UserProduct> UserProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
    {
      if (!optionsbuilder.IsConfigured)
      {
        // #warning to protect potentially sensitive information in your connection string, you should move it out of source code. you can avoid scaffolding the connection string by using the name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. for more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?linkid=723263.
        // optionsbuilder.usesqlserver("server=08162021dotnetuta.database.windows.net;database=shopdb;user id=sqladmin;password=password12345;");
        optionsbuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=shopdb;trusted_connection=true;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Product>(entity =>
      {
        entity.ToTable("Product");

        entity.Property(e => e.ProductDescription)
                  .IsRequired()
                  .HasMaxLength(500)
                  .IsUnicode(false);

        entity.Property(e => e.ProductDiscount).HasColumnType("decimal(19, 4)");

        entity.Property(e => e.ProductName)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

        entity.Property(e => e.ProductPrice).HasColumnType("decimal(19, 4)");

        entity.HasOne(d => d.Seasonal)
                  .WithMany(p => p.Products)
                  .HasForeignKey(d => d.SeasonalId)
                  .HasConstraintName("FK__Product__Seasona__25869641");
      });

      modelBuilder.Entity<Seasonal>(entity =>
      {
        entity.ToTable("Seasonal");

        entity.Property(e => e.SeasonalName)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);
      });

      modelBuilder.Entity<UserProduct>(entity =>
      {
        entity.ToTable("UserProduct");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.UserProducts)
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__UserProdu__Produ__32E0915F");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
