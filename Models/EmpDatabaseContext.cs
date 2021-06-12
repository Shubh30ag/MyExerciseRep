using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CoreMVCWithAzureDatabase.Models
{
    public partial class EmpDatabaseContext : DbContext
    {
        public EmpDatabaseContext()
        {
        }

        public EmpDatabaseContext(DbContextOptions<EmpDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpSalaryInfo> EmpSalaryInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:shubhamnewserver.database.windows.net,1433;Initial Catalog=EmpDatabase;Persist Security Info=False;User ID=shubham12345;Password=shubham@12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpSalaryInfo>(entity =>
            {
                entity.HasKey(e => e.PayBand)
                    .HasName("PK__EmpSalar__66B0F53FD7013562");

                entity.Property(e => e.PayBand).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
