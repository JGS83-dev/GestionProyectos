namespace GestionProyectos.Models
{
    public class RolesProyecto
    {
        public int Id { get; set; }

        public string NombreRolProyecto { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
