using System.ComponentModel.DataAnnotations;

namespace PTSeleccion.Backend.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        // Otras propiedades de la opción

        // Relación con Question
        public Question Question { get; set; }
    }
}