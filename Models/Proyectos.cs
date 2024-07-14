using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectos.Models
{
    public class Proyectos
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string NombreProyecto { get; set; }

        [StringLength(250)]
        [Required]
        public string DescripcionProyecto { get; set; }
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignaciones> Asignaciones { get; set; }
    }
}
