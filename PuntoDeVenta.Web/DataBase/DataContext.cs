using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Common.Entities;
using System.Linq;

namespace PuntoDeVenta.Web.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<cState> cState { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<entrada> Entrada { get; set; }
        public DbSet<detalle_entrada> Detalle_Entrada { get; set; }
        public DbSet<TblTmpDetailenter> tblTmpDetailenter { get; set; }
        public DbSet<venta> Venta { get; set; }
        public DbSet<detalle_venta>  Detalle_Venta { get; set; }
        public DbSet<tblTmpDetailSales> tblTmpDetailSales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
