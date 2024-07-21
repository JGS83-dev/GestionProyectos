using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class PuestoEmpleado
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del puesto del empleado")]
        [Required(ErrorMessage = "El Nombre del puesto del empleado es requerido")]

        public string NombrePuestoEmpleado { get; set; }

        public ICollection<Empleados> Empleados { get; set; }
    }
}
