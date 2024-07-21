using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Asignaciones
    {
        public int Id { get; set; }
        public DateTime FechaAsignacion { get; set; }

        //Proyecto al cual se realiza la asignacion
        [ForeignKey("Proyectos")]
        [Display(Name = "Proyecto")]
        [Required(ErrorMessage = "El proyecto es requerido")]
        public int? ProyectoId { get; set; }

        public Proyectos Proyectos { get; set; }

        //Empleado Asignado
        [Display(Name = "Empleado asignado")]
        [Required(ErrorMessage = "El empleado es requerido")]
        [ForeignKey("Empleados")]
        public int? EmpleadoId { get; set; }

        public Empleados Empleados { get; set; }

        //Rol Asignado

        [Display(Name = "Rol del empleado en el proyecto")]
        [Required(ErrorMessage = "El Rol del empleado en el proyecto es requerido")]
        [ForeignKey("RolesProyecto")]
        public int? RolProyectoId { get; set; }

        public RolesProyecto RolesProyecto { get; set; }
    }
}
