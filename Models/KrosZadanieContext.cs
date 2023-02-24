using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KROS_Pohovor.Models;

public partial class KrosZadanieContext : DbContext
{
    public KrosZadanieContext()
    {
    }

    public KrosZadanieContext(DbContextOptions<KrosZadanieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Divizie> Divizies { get; set; }

    public virtual DbSet<Firmy> Firmies { get; set; }

    public virtual DbSet<Oddelenium> Oddelenia { get; set; }

    public virtual DbSet<Projekty> Projekties { get; set; }

    public virtual DbSet<Zamestnanci> Zamestnancis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress01;Database=KROS_Zadanie;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Divizie>(entity =>
        {
            entity.HasKey(e => e.KodDivizie);

            entity.ToTable("Divizie");

            entity.Property(e => e.KodDivizie).ValueGeneratedNever();
            entity.Property(e => e.KodRodicaFirma).HasColumnName("KodRodica_Firma");
            entity.Property(e => e.NazovDivizie).HasMaxLength(50);

            entity.HasOne(d => d.IdVeducehoDivizieNavigation).WithMany(p => p.Divizies)
                .HasForeignKey(d => d.IdVeducehoDivizie)
                .HasConstraintName("FK_Divizie_Zamestnanci");

            entity.HasOne(d => d.KodRodicaFirmaNavigation).WithMany(p => p.Divizies)
                .HasForeignKey(d => d.KodRodicaFirma)
                .HasConstraintName("FK_Divizie_Firmy");
        });

        modelBuilder.Entity<Firmy>(entity =>
        {
            entity.HasKey(e => e.KodFirmy);

            entity.ToTable("Firmy");

            entity.Property(e => e.KodFirmy).ValueGeneratedNever();
            entity.Property(e => e.NazovFirmy).HasMaxLength(50);

            entity.HasOne(d => d.IdRiaditelaNavigation).WithMany(p => p.Firmies)
                .HasForeignKey(d => d.IdRiaditela)
                .HasConstraintName("FK_Firmy_Zamestnanci");
        });

        modelBuilder.Entity<Oddelenium>(entity =>
        {
            entity.HasKey(e => e.KodOddelenia);

            entity.Property(e => e.KodOddelenia).ValueGeneratedNever();
            entity.Property(e => e.KodRodicaProjekt).HasColumnName("KodRodica_Projekt");
            entity.Property(e => e.NazovOddelenia).HasMaxLength(50);

            entity.HasOne(d => d.IdVeducehoOddeleniaNavigation).WithMany(p => p.Oddelenia)
                .HasForeignKey(d => d.IdVeducehoOddelenia)
                .HasConstraintName("FK_Oddelenia_Zamestnanci");

            entity.HasOne(d => d.KodRodicaProjektNavigation).WithMany(p => p.Oddelenia)
                .HasForeignKey(d => d.KodRodicaProjekt)
                .HasConstraintName("FK_Oddelenia_Projekty");
        });

        modelBuilder.Entity<Projekty>(entity =>
        {
            entity.HasKey(e => e.KodProjektu);

            entity.ToTable("Projekty");

            entity.Property(e => e.KodProjektu).ValueGeneratedNever();
            entity.Property(e => e.KodRodicaDivizia).HasColumnName("KodRodica_Divizia");
            entity.Property(e => e.NazovProjektu).HasMaxLength(50);

            entity.HasOne(d => d.IdVeducehoProjektuNavigation).WithMany(p => p.Projekties)
                .HasForeignKey(d => d.IdVeducehoProjektu)
                .HasConstraintName("FK_Projekty_Zamestnanci");

            entity.HasOne(d => d.KodRodicaDiviziaNavigation).WithMany(p => p.Projekties)
                .HasForeignKey(d => d.KodRodicaDivizia)
                .HasConstraintName("FK_Projekty_Divizie");
        });

        modelBuilder.Entity<Zamestnanci>(entity =>
        {
            entity.ToTable("Zamestnanci");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdFirmyZamestnanca).HasColumnName("id_firmy_zamestnanca");
            entity.Property(e => e.Meno).HasMaxLength(50);
            entity.Property(e => e.Priezvisko).HasMaxLength(50);
            entity.Property(e => e.TelefonneCislo).HasMaxLength(50);
            entity.Property(e => e.Titul).HasMaxLength(50);

            entity.HasOne(d => d.IdFirmyZamestnancaNavigation).WithMany(p => p.Zamestnancis)
                .HasForeignKey(d => d.IdFirmyZamestnanca)
                .HasConstraintName("FK_Zamestnanci_Firmy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
