using System.ComponentModel.DataAnnotations;

namespace PTSeleccion.Backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        // Otras propiedades relacionadas con la categoría si es necesario
    }
}
