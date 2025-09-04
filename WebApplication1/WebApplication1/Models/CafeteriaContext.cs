using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebApplication1.Models;

public partial class CafeteriaContext : DbContext
{
    public CafeteriaContext()
    {
    }

    public CafeteriaContext(DbContextOptions<CafeteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<detallepedido> detallepedidos { get; set; }

    public virtual DbSet<pedido> pedidos { get; set; }

    public virtual DbSet<producto> productos { get; set; }

    public virtual DbSet<usuario> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=cafeteria_universitaria;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<detallepedido>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.ToTable("detallepedido");

            entity.HasIndex(e => e.PedidoID, "PedidoID");

            entity.HasIndex(e => e.ProductoID, "ProductoID");

            entity.Property(e => e.Subtotal).HasPrecision(10, 2);

            entity.HasOne(d => d.Pedido).WithMany(p => p.detallepedidos)
                .HasForeignKey(d => d.PedidoID)
                .HasConstraintName("detallepedido_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.detallepedidos)
                .HasForeignKey(d => d.ProductoID)
                .HasConstraintName("detallepedido_ibfk_2");
        });

        modelBuilder.Entity<pedido>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.HasIndex(e => e.UsuarioID, "UsuarioID");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.Usuario).WithMany(p => p.pedidos)
                .HasForeignKey(d => d.UsuarioID)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<producto>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
