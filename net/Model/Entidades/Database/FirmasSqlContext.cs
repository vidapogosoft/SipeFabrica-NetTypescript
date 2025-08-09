using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.Entidades.Database;

public partial class FirmasSqlContext : DbContext
{
    public FirmasSqlContext()
    {
    }

    public FirmasSqlContext(DbContextOptions<FirmasSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BitacoraCatImagen> BitacoraCatImagens { get; set; }

    public virtual DbSet<BitacoraFirmaAutorizada> BitacoraFirmaAutorizadas { get; set; }

    public virtual DbSet<BitacoraSolicitudFirma> BitacoraSolicitudFirmas { get; set; }

    public virtual DbSet<BitacoraUsuario> BitacoraUsuarios { get; set; }

    public virtual DbSet<CatCliente> CatClientes { get; set; }

    public virtual DbSet<CatImagen> CatImagens { get; set; }

    public virtual DbSet<CatParametro> CatParametros { get; set; }

    public virtual DbSet<ConfigurationProfile> ConfigurationProfiles { get; set; }

    public virtual DbSet<Corresponsal> Corresponsals { get; set; }

    public virtual DbSet<Dtproperty> Dtproperties { get; set; }

    public virtual DbSet<FirmasAutorizada> FirmasAutorizadas { get; set; }

    public virtual DbSet<LogRolUsuario> LogRolUsuarios { get; set; }

    public virtual DbSet<LogUsuario> LogUsuarios { get; set; }

    public virtual DbSet<Mcb> Mcbs { get; set; }

    public virtual DbSet<Passtest> Passtests { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<TipoFirma> TipoFirmas { get; set; }

    public virtual DbSet<TransactionAction> TransactionActions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("User= sa; Password= Ctek2314;Persist Security Info=False;Initial Catalog=FirmasSQL;Data Source=(local)\\A22; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<BitacoraCatImagen>(entity =>
        {
            entity.HasKey(e => e.IdBitacora);

            entity.ToTable("BitacoraCatImagen");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Imagen).HasColumnType("image");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BitacoraFirmaAutorizada>(entity =>
        {
            entity.HasKey(e => e.IdBitacora);

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Comentarios).IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Firma)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoFirma)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BitacoraSolicitudFirma>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__Bitacora__ED3A1B1350D5DA77");

            entity.ToTable("BitacoraSolicitudFirma");

            entity.Property(e => e.Accion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaAprobacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud).HasColumnType("datetime");
            entity.Property(e => e.IdFirma)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioAprobador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BitacoraUsuario>(entity =>
        {
            entity.HasKey(e => e.IdBitacoraUsuario);

            entity.ToTable("BitacoraUsuario");

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasMaxLength(50);
        });

        modelBuilder.Entity<CatCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAT_CLIENTES");

            entity.Property(e => e.Foto)
                .HasColumnType("image")
                .HasColumnName("FOTO");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(50)
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<CatImagen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CatImagen");

            entity.Property(e => e.IdImagen).ValueGeneratedOnAdd();
            entity.Property(e => e.Imagen).HasColumnType("image");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatParametro>(entity =>
        {
            entity.HasKey(e => e.IdCat);

            entity.Property(e => e.Parametro).HasMaxLength(100);
            entity.Property(e => e.Valor).HasMaxLength(100);
        });

        modelBuilder.Entity<ConfigurationProfile>(entity =>
        {
            entity.HasKey(e => e.IdConfiguration).HasName("PK__Configur__2C0725D14517B0A8");

            entity.ToTable("ConfigurationProfile");

            entity.Property(e => e.DateRecord).HasColumnType("datetime");
            entity.Property(e => e.NameProfile).IsUnicode(false);
            entity.Property(e => e.StatusProfile).IsUnicode(false);
        });

        modelBuilder.Entity<Corresponsal>(entity =>
        {
            entity.HasKey(e => e.IdCorresponsal).HasName("PK__correspo__F1B9C3233BFCD869");

            entity.ToTable("corresponsal");

            entity.HasIndex(e => e.User, "UN_user").IsUnique();

            entity.Property(e => e.Banco).HasMaxLength(50);
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .HasColumnName("contacto");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Intentos).HasColumnName("intentos");
            entity.Property(e => e.IntentosTimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("intentosTimeStamp");
            entity.Property(e => e.OtpActivate).HasColumnName("otp_activate");
            entity.Property(e => e.OtpSecret)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("otp_secret");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Passanterior)
                .HasMaxLength(50)
                .HasColumnName("passanterior");
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .HasColumnName("user");
        });

        modelBuilder.Entity<Dtproperty>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Property }).HasName("pk_dtproperties");

            entity.ToTable("dtproperties");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Property)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("property");
            entity.Property(e => e.Lvalue)
                .HasColumnType("image")
                .HasColumnName("lvalue");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Uvalue)
                .HasMaxLength(255)
                .HasColumnName("uvalue");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("value");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<FirmasAutorizada>(entity =>
        {
            entity.HasKey(e => e.Secuencial);

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Comentarios).IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Firma)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioModifico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogBitacAut).IsUnicode(false);
            entity.Property(e => e.LogSolFirma).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoFirma)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<LogRolUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LogRolUsuario");

            entity.Property(e => e.Accion)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdUsuarioAsigna)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<LogUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LogUsuario");

            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(125)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifico).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioModifico)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Mcb>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__mcb__AB6E61659BC89350");

            entity.ToTable("mcb");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Asunto1)
                .HasMaxLength(100)
                .HasColumnName("asunto1");
            entity.Property(e => e.Asunto2)
                .HasMaxLength(100)
                .HasColumnName("asunto2");
            entity.Property(e => e.Asunto3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asunto3");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Cuerpomensaje1)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("cuerpomensaje1");
            entity.Property(e => e.Cuerpomensaje2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("cuerpomensaje2");
            entity.Property(e => e.Cuerpomensaje3)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("cuerpomensaje3");
            entity.Property(e => e.Fechaactualizacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Idioma)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Smtp)
                .HasMaxLength(50)
                .HasColumnName("SMTP");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Passtest>(entity =>
        {
            entity.HasKey(e => e.IdPasstest).HasName("PK__passtest__151D7FC83B2E7507");

            entity.ToTable("passtest");

            entity.Property(e => e.Passtemporal)
                .HasMaxLength(50)
                .HasColumnName("passtemporal");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rol");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioModifico)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RolUsuario");

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoFirma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TipoFirma");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TipoFirma1)
                .ValueGeneratedOnAdd()
                .HasColumnName("TipoFirma");
        });

        modelBuilder.Entity<TransactionAction>(entity =>
        {
            entity.HasKey(e => e.IdTran).HasName("PK__Transact__9B5553DD5E254C3B");

            entity.ToTable("TransactionAction", tb => tb.HasTrigger("TranSendEmail"));

            entity.Property(e => e.ActionTran).IsUnicode(false);
            entity.Property(e => e.DateRecord).HasColumnType("datetime");
            entity.Property(e => e.Enviado)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.KeyTran).IsUnicode(false);
            entity.Property(e => e.MessagesTran).IsUnicode(false);
            entity.Property(e => e.TableTran).IsUnicode(false);
            entity.Property(e => e.Value1Tran).IsUnicode(false);
            entity.Property(e => e.Value2Tran).IsUnicode(false);
            entity.Property(e => e.Value3Tran).IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Usuario");

            entity.HasIndex(e => e.IdUsuario, "UN_IdUsuario").IsUnique();

            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(125)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifico).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioModifico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("O")
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
