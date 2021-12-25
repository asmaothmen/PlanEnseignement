using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignement.Models
{
    public partial class PlanEnseignementContext : DbContext
    {
        public PlanEnseignementContext()
        {
        }

        public PlanEnseignementContext(DbContextOptions<PlanEnseignementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Parcours> Parcours { get; set; }
        public virtual DbSet<UniteEnseignement> UniteEnseignement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RIP3HIO\\SQLEXPRESS;Database=PlanEnseignement;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Filiere")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeDepartementTutelle)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeTypeDiplome)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeTypePeriodeEnseignement)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Domaine)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Mention)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeHabilitation)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(e => e.Credits)
                    .HasName("IX_Module_3")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Module")
                    .IsUnique();

                entity.HasIndex(e => e.IntituleAbrege)
                    .HasName("IX_Module_2")
                    .IsUnique();

                entity.HasIndex(e => e.IntituleFr)
                    .HasName("IX_Module_1")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeFiliere)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeNiveau)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeParcours)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RegimeExamen)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UniteVolumeHoraire)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeCi).HasColumnName("VolumeCI");

                entity.Property(e => e.VolumeTd).HasColumnName("VolumeTD");

                entity.Property(e => e.VolumeTp).HasColumnName("VolumeTP");

                entity.HasOne(d => d.CodeFiliereNavigation)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.CodeFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Filiere");

                entity.HasOne(d => d.CodeNiveauNavigation)
                    .WithMany(p => p.Module)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeNiveau)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Niveau");

                entity.HasOne(d => d.CodeParcoursNavigation)
                    .WithMany(p => p.Module)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeParcours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Parcours");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.CodeFiliere });

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Niveau")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeFiliere).HasMaxLength(32);

                entity.Property(e => e.IntituleAbrege)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parcours>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.CodeFiliere });

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Parcours")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeFiliere)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeFiliereNavigation)
                    .WithMany(p => p.Parcours)
                    .HasForeignKey(d => d.CodeFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcours_Filiere");
            });

            modelBuilder.Entity<UniteEnseignement>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("IX_UniteEnseignement_1")
                    .IsUnique();

                entity.HasIndex(e => e.CodeFiliere)
                    .HasName("IX_UniteEnseignement_2")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("IX_UniteEnseignement")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeFiliere)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeNiveau)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeParcours)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nature)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeFiliereNavigation)
                    .WithOne(p => p.UniteEnseignement)
                    .HasForeignKey<UniteEnseignement>(d => d.CodeFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniteEnseignement_Filiere");

                entity.HasOne(d => d.CodeNiveauNavigation)
                    .WithMany(p => p.UniteEnseignement)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeNiveau)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniteEnseignement_Niveau");

                entity.HasOne(d => d.CodeParcoursNavigation)
                    .WithMany(p => p.UniteEnseignement)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.CodeParcours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniteEnseignement_Parcours");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
