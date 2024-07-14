using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string NombreEmpleado { get; set; }

        [StringLength(250)]
        [Required]
        public string ApellidoEmpleado { get; set; }
        public DateTime FechaContratacion { get; set; }

        [Required]
        [ForeignKey("PuestoEmpleado")]
        public int? PuestoId { get; set; }

        public PuestoEmpleado PuestoEmpleado { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
