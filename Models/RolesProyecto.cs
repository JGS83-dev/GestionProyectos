using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class RolesProyecto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Rol de proyecto")]
        [Required(ErrorMessage = "El Nombre del Rol de proyecto es requerido")]
        public string NombreRolProyecto { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
