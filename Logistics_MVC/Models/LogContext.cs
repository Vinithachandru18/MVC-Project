using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Logistics_MVC.Models;

namespace Logistics_MVC.Models;

public partial class LogContext : DbContext
{
    public LogContext()
    {
    }

    public LogContext(DbContextOptions<LogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Logistic> Logistics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=log;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Logistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logistic__3214EC078756DFF8");

            entity.HasIndex(e => e.PackageId, "UQ__Logistic__B7FDB533CA4D7BEB").IsUnique();

            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Delivery_status");
            entity.Property(e => e.ExpectedDate).HasColumnName("Expected_date");
            entity.Property(e => e.FromLocation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("From_location");
            entity.Property(e => e.Ownername)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PackageId).HasColumnName("Package_id");
            entity.Property(e => e.PackedDate).HasColumnName("Packed_date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Product_name");
            entity.Property(e => e.ToLocation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("To_location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Logistics_MVC.Models.login_details> login_details { get; set; } = default!;
}
