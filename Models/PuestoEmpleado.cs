namespace GestionProyectos.Models
{
    public class PuestoEmpleado
    {
        public int Id { get; set; }

        public string NombrePuestoEmpleado { get; set; }

        public ICollection<Empleados> Empleados { get; set; }
    }
}
