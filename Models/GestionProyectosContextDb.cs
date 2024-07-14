using Microsoft.EntityFrameworkCore;

namespace GestionProyectos.Models
{
    public class GestionProyectosContextDb: DbContext
    {
        public GestionProyectosContextDb(DbContextOptions options) : base(options)
        {

        }
    }
}
