using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name = "Nombre del empleado")]
        [Required(ErrorMessage = "El nombre del empleado es requerido")]
        public string NombreEmpleado { get; set; }

        [StringLength(250)]
        [Display(Name = "Apellido del empleado")]
        [Required(ErrorMessage = "El apellido del empleado es requerido")]
        public string ApellidoEmpleado { get; set; }

        [Display(Name = "Fecha de contratación")]
        [Required(ErrorMessage = "La fecha de contratación es requerida")]
        public DateTime FechaContratacion { get; set; }

        [Display(Name = "Puesto del empleado")]
        [Required(ErrorMessage = "El puesto del empleado es requerido")]
        [ForeignKey("PuestoEmpleado")]
        public int? PuestoId { get; set; }

        public PuestoEmpleado PuestoEmpleado { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
