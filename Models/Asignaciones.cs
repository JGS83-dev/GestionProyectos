using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Asignaciones
    {
        public int Id { get; set; }
        public DateTime FechaAsignacion { get; set; }

        //Proyecto al cual se realiza la asignacion
        [Required]
        [ForeignKey("Proyectos")]
        public int? ProyectoId { get; set; }

        public Proyectos Proyectos { get; set; }

        //Empleado Asignado
        [Required]
        [ForeignKey("Empleados")]
        public int? EmpleadoId { get; set; }

        public Empleados Empleados { get; set; }

        //Rol Asignado

        [Required]
        [ForeignKey("RolesProyecto")]
        public int? RolProyectoId { get; set; }

        public RolesProyecto RolesProyecto { get; set; }
    }
}
