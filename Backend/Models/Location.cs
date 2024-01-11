using System.ComponentModel.DataAnnotations;

namespace PTSeleccion.Backend.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        // Otras propiedades relacionadas con la ubicación si es necesario
    }
}
