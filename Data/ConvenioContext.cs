using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Be3Tech.WebAPI.Models;

#nullable disable

namespace Be3Tech.WebAPI.Data
{
    public partial class ConvenioContext : DbContext
    {
        public ConvenioContext()
        {
        }

        public ConvenioContext(DbContextOptions<ConvenioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Convenio> Convenios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.IdConvenio);

                entity.Property(e => e.IdConvenio).HasColumnName("ID_Convenio");

                entity.Property(e => e.Empresa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
