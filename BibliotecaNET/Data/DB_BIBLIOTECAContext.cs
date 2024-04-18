using System;
using System.Collections.Generic;
using BibliotecaNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaNET.Data
{
    public partial class DB_BIBLIOTECAContext : DbContext
    {
        public DB_BIBLIOTECAContext()
        {
        }

        public DB_BIBLIOTECAContext(DbContextOptions<DB_BIBLIOTECAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Editorial> Editorials { get; set; } = null!;
        public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__AUTOR__DD33B031D02FED40");

                entity.ToTable("AUTOR");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__A3C02A10BD61E008");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PK__EDITORIA__EF8386716A727D4C");

                entity.ToTable("EDITORIAL");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EstadoPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPrestamo)
                    .HasName("PK__ESTADO_P__BCB875498C0259C1");

                entity.ToTable("ESTADO_PRESTAMO");

                entity.Property(e => e.IdEstadoPrestamo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__LIBRO__3E0B49AD869E9C68");

                entity.ToTable("LIBRO");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombrePortada)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RutaPortada)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK__LIBRO__IdAutor__4316F928");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__LIBRO__IdCategor__440B1D61");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK__LIBRO__IdEditori__44FF419A");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__PERSONA__2EC8D2ACA360A485");

                entity.ToTable("PERSONA");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .HasConstraintName("FK__PERSONA__IdTipoP__4D94879B");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__PRESTAMO__6FF194C0232BB26F");

                entity.ToTable("PRESTAMO");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.EstadoEntregado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoRecibido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaConfirmacionDevolucion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

                entity.HasOne(d => d.IdEstadoPrestamoNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdEstadoPrestamo)
                    .HasConstraintName("FK__PRESTAMO__IdEsta__5629CD9C");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__PRESTAMO__IdLibr__5812160E");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__PRESTAMO__IdPers__571DF1D5");
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.HasKey(e => e.IdTipoPersona)
                    .HasName("PK__TIPO_PER__79FCAFBFFD7A7F93");

                entity.ToTable("TIPO_PERSONA");

                entity.Property(e => e.IdTipoPersona).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
