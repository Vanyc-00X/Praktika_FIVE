using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FIVE.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaPol> BaPols { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Human> Humans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql-ser-larisa\\serv1215;Database=PrakFIVE;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaPol>(entity =>
        {
            entity.HasKey(e => e.IdBa);

            entity.ToTable("ba_pol");

            entity.Property(e => e.IdBa).HasColumnName("id_Ba");
            entity.Property(e => e.Count)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("COUNT");
            entity.Property(e => e.IdTovar)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("Id_Tovar");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BaPols)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ba_pol_User");
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.IdBasket);

            entity.ToTable("Basket");

            entity.Property(e => e.IdBasket).HasColumnName("Id_Basket");
            entity.Property(e => e.CountTovar).HasColumnName("Count_tovar");
            entity.Property(e => e.IdTovar).HasColumnName("Id_Tovar");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");

            entity.HasOne(d => d.IdTovarNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdTovar)
                .HasConstraintName("FK_Basket_Tovar");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Basket_User");
        });

        modelBuilder.Entity<Human>(entity =>
        {
            entity.HasKey(e => e.IdHuman);

            entity.ToTable("Human");

            entity.Property(e => e.IdHuman).HasColumnName("Id_Human");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.NameRole).HasColumnType("text");
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.IdTovar);

            entity.ToTable("Tovar");

            entity.Property(e => e.IdTovar).HasColumnName("Id_Tovar");
            entity.Property(e => e.NameTovar).HasColumnType("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.IdHuman).HasColumnName("Id_Human");
            entity.Property(e => e.IdRole)
                .HasDefaultValue(3)
                .HasColumnName("Id_Role");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdHumanNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdHuman)
                .HasConstraintName("FK_User_Human");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
