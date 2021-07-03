using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Common.Entities;

namespace PuntoDeVenta.Web.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<cState> cState { get; set; }
    }
}
