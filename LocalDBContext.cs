using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Practice.Models;

namespace Practice.Models
{
    public partial class LocalDBContext : DbContext
    {
        public LocalDBContext()
        {
        }

        public LocalDBContext(DbContextOptions<LocalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOutlet> TblOutlet { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IEEGDH1;Database=LocalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOutlet>(entity =>
            {
                entity.ToTable("tbl_outlet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.TblOutlet)
                    .HasForeignKey(d => d.FkUser)
                    .HasConstraintName("FK_tbl_outlet_tbl_Users");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tbl_Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }

        public DbSet<Practice.Models.tbl_CauseOfDeath> tbl_CauseOfDeath { get; set; }
    }
}
