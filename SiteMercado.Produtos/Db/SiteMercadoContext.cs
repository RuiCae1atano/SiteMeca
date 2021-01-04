using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteMercado.Api.Produtos.Db
{
    public partial class SiteMercadoContext : DbContext
    {
        public SiteMercadoContext()
        {
        }

        public SiteMercadoContext(DbContextOptions<SiteMercadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer
                    ("Data Source=DESKTOP-16139R4\\SQLEXPRESS;Initial Catalog=SiteMercado;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Imagem).IsRequired();

                entity.Property(e => e.Nome).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
