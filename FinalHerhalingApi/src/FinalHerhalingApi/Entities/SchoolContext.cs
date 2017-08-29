using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalHerhalingApi.Entities
{
    public partial class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-Q8LPA78\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boete>(entity =>
            {
                entity.HasKey(e => e.Studnr)
                    .HasName("PK__boete__E271D824F56ACB54");

                entity.ToTable("boete");

                entity.Property(e => e.Studnr)
                    .HasColumnName("studnr")
                    .ValueGeneratedNever();

                entity.Property(e => e.Boet).HasColumnName("boet");

                entity.HasOne(d => d.StudnrNavigation)
                    .WithOne(p => p.BoeteNavigation)
                    .HasForeignKey<Boete>(d => d.Studnr)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__boete__studnr__17036CC0");
            });

            modelBuilder.Entity<Cursussen>(entity =>
            {
                entity.HasKey(e => e.Cursusnr)
                    .HasName("pk_cursussen");

                entity.ToTable("cursussen");

                entity.Property(e => e.Cursusnr).HasColumnName("cursusnr");

                entity.Property(e => e.Cursusnaam)
                    .HasColumnName("cursusnaam")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Inschrijvingsgeld).HasColumnName("inschrijvingsgeld");

                entity.Property(e => e.Leerkracht).HasColumnName("leerkracht");

                entity.HasOne(d => d.LeerkrachtNavigation)
                    .WithMany(p => p.Cursussen)
                    .HasForeignKey(d => d.Leerkracht)
                    .HasConstraintName("FK__cursussen__leerk__60A75C0F");
            });

            modelBuilder.Entity<Leerkrachten>(entity =>
            {
                entity.ToTable("leerkrachten");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Achternaam)
                    .IsRequired()
                    .HasColumnName("achternaam")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Studenten>(entity =>
            {
                entity.HasKey(e => e.Studnr)
                    .HasName("pk_studenten");

                entity.ToTable("studenten");

                entity.HasIndex(e => e.Familienaam)
                    .HasName("famIndex");

                entity.Property(e => e.Studnr).HasColumnName("studnr");

                entity.Property(e => e.Betaald)
                    .HasColumnName("betaald")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Boete).HasColumnName("boete");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Familienaam)
                    .HasColumnName("familienaam")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Geboortedatum)
                    .HasColumnName("geboortedatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Geslacht)
                    .HasColumnName("geslacht")
                    .HasColumnType("char(1)");

                entity.Property(e => e.PeterMeter).HasColumnName("peter/meter");

                entity.Property(e => e.Voornaam)
                    .HasColumnName("voornaam")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Woonplaats)
                    .HasColumnName("woonplaats")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.PeterMeterNavigation)
                    .WithMany(p => p.InversePeterMeterNavigation)
                    .HasForeignKey(d => d.PeterMeter)
                    .HasConstraintName("FK__studenten__peter__5DCAEF64");
            });

            modelBuilder.Entity<StudentenCursussen>(entity =>
            {
                entity.HasKey(e => new { e.Studnr, e.Cursusnr })
                    .HasName("pk_stud_curs");

                entity.ToTable("studenten_cursussen");

                entity.Property(e => e.Studnr).HasColumnName("studnr");

                entity.Property(e => e.Cursusnr).HasColumnName("cursusnr");

                entity.HasOne(d => d.CursusnrNavigation)
                    .WithMany(p => p.StudentenCursussen)
                    .HasForeignKey(d => d.Cursusnr)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk2_stud_curs");

                entity.HasOne(d => d.StudnrNavigation)
                    .WithMany(p => p.StudentenCursussen)
                    .HasForeignKey(d => d.Studnr)
                    .HasConstraintName("fk1_stud_curs");
            });
        }

        public virtual DbSet<Boete> Boete { get; set; }
        public virtual DbSet<Cursussen> Cursussen { get; set; }
        public virtual DbSet<Leerkrachten> Leerkrachten { get; set; }
        public virtual DbSet<Studenten> Studenten { get; set; }
        public virtual DbSet<StudentenCursussen> StudentenCursussen { get; set; }
    }
}