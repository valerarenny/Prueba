using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EtechApi.Models
{
    public partial class ViajesDBRestContext : DbContext
    {
        public ViajesDBRestContext()
        {
        }

        public ViajesDBRestContext(DbContextOptions<ViajesDBRestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleto> Boletos { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }
        public virtual DbSet<Viajero> Viajeros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ViajesDBRest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasKey(e => e.IdBoleto);

                entity.ToTable("Boleto");

                entity.Property(e => e.IdBoleto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Id_Boleto");

                entity.Property(e => e.IdViaje).HasColumnName("Id_Viaje");

                entity.Property(e => e.IdViajero).HasColumnName("Id_Viajero");

                entity.HasOne(d => d.IdViajeNavigation)
                    .WithMany(p => p.Boletos)
                    .HasForeignKey(d => d.IdViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Boleto_Viaje");

                entity.HasOne(d => d.IdViajeroNavigation)
                    .WithMany(p => p.Boletos)
                    .HasForeignKey(d => d.IdViajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Boleto_Viajero");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.IdViaje);

                entity.ToTable("Viaje");

                entity.Property(e => e.IdViaje)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Viaje");

                entity.Property(e => e.Destino).HasMaxLength(100);

                entity.Property(e => e.Origen).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<Viajero>(entity =>
            {
                entity.HasKey(e => e.IdViajero);

                entity.ToTable("Viajero");

                entity.Property(e => e.IdViajero)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Viajero");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
