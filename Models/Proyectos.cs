using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Proyectos
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name = "Nombre del proyecto")]
        [Required(ErrorMessage = "El proyecto es requerido")]
        public string NombreProyecto { get; set; }

        [StringLength(250)]
        [Display(Name = "Descripcion del proyecto")]
        [Required(ErrorMessage = "La Descripcion es requerida")]
        public string DescripcionProyecto { get; set; }

        [Display(Name = "Fecha de inicio del proyecto")]
        [Required(ErrorMessage = "La Fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
