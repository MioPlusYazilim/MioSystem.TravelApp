using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MioSystem.TravelApp.Infrastructure.Data.Entities;

namespace MioSystem.TravelApp.Infrastructure.Data;

public partial class TravelAppDbContext : DbContext
{
    public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SysLanguage> SysLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysLanguage>(entity =>
        {
            entity.ToTable("SysLanguage");

            entity.HasIndex(e => e.Code, "UQ_SysLanguage_Code").IsUnique();

            entity.HasIndex(e => e.ShortCode, "UQ_SysLanguage_ShortCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CultureName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ShortCode).HasMaxLength(5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
