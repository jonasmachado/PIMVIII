using System.Data.Entity;
using MyPOS.Dominio.Entidades;

namespace MyPOS.Repositorio.Context
{
    public class MyPOSContext:DbContext
    {
        public MyPOSContext():base("PgMyPOS")
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
