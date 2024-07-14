using Microsoft.EntityFrameworkCore;
using GestionProyectos.Models;

namespace GestionProyectos.Models
{
    public class GestionProyectosContextDb: DbContext
    {
        public GestionProyectosContextDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RolesProyecto> RolesProyectos { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<GestionProyectos.Models.PuestoEmpleado> PuestoEmpleado { get; set; } = default!;
    }
}
