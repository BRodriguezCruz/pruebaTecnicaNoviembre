using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class PruebaTecnicaNoviembreContext : DbContext
    {
        public PruebaTecnicaNoviembreContext()
        {
        }

        public PruebaTecnicaNoviembreContext(DbContextOptions<PruebaTecnicaNoviembreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Celular> Celulars { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6OBJBAUI; Database= PruebaTecnicaNoviembre; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Celular>(entity =>
            {
                entity.HasKey(e => e.IdCelular)
                    .HasName("PK__Celular__5F10A160288E1D36");

                entity.ToTable("Celular");

                entity.Property(e => e.FechaLanzamiento).HasColumnType("date");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Celulars)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Celular__IdMarca__1273C1CD");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__4076A887FA035432");

                entity.ToTable("Marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
