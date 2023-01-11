using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL.Models
{
    public partial class ColorCollection_2ALLContext : DbContext
    {
        public ColorCollection_2ALLContext()
        {
        }

        public ColorCollection_2ALLContext(DbContextOptions<ColorCollection_2ALLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-MQD9E13;Database=ColorCollection_2ALL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color1)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.Desc)
                    .HasMaxLength(50)
                    .HasColumnName("desc");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
