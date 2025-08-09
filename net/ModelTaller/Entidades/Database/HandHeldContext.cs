using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ModelTaller.Entidades.DTO;

namespace ModelTaller.Entidades.Database;

public partial class HandHeldContext : DbContext
{
    public HandHeldContext()
    {
    }

    public HandHeldContext(DbContextOptions<HandHeldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderPedido> OrderPedidos { get; set; }

    public virtual DbSet<OrderPedidoDetalle> OrderPedidoDetalles { get; set; }

    public virtual DbSet<DTOPedidoDetalle> PedidoDetalle { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("User= sa; Password= Ctek2314;Persist Security Info=False;Initial Catalog=HandHeld;Data Source=(local)\\A22; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderPedido>(entity =>
        {
            entity.HasKey(e => e.IdOrderCab).HasName("PK__OrderPed__79BBBE9005916E89");

            entity.ToTable("OrderPedido", tb => tb.HasTrigger("FixIssueDispoItemv4"));

            entity.Property(e => e.CodTienda).IsUnicode(false);
            entity.Property(e => e.Detalle)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Enviado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaIngresoConsulta).IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSyncIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSyncIngresoConsulta).IsUnicode(false);
            entity.Property(e => e.GestionadoPor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JsonOrder).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.Tienda).IsUnicode(false);
            entity.Property(e => e.UsuarioIngreso)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderPedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdOrderDet).HasName("PK__OrderPed__79FB98762A4FA829");

            entity.ToTable("OrderPedidoDetalle", tb => tb.HasTrigger("TranOrderPedidoDetalle"));

            entity.Property(e => e.CodItem).IsUnicode(false);
            entity.Property(e => e.CodTienda).IsUnicode(false);
            entity.Property(e => e.DescripcionItem).IsUnicode(false);
            entity.Property(e => e.Enviado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaIngresoConsulta).IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSyncIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSyncIngresoConsulta).IsUnicode(false);
            entity.Property(e => e.NombreDispo).IsUnicode(false);
            entity.Property(e => e.Tienda).IsUnicode(false);
            entity.Property(e => e.UsuarioIngreso)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
