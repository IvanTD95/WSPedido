using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSPedido.Datos.Contexto
{
    public partial class TRUPERContex : DbContext
    {
        public TRUPERContex()
        {
        }

        public TRUPERContex(DbContextOptions<TRUPERContex> options)
            : base(options)
        {
        }

        public virtual DbSet<Pedido> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6HQC8G9;Database=TRUPER; User ID=sa;Password=sasa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => new { e.IdPedido, e.Sku })
                    .HasName("PK__Pedido__7557F547975B3090");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
