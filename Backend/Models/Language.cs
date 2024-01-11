using System.Collections.Generic;

namespace PTSeleccion.Backend.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        // Relación con pruebas de selección
        public ICollection<Process> Processes { get; set; } // Pruebas de selección que evalúan este lenguaje

        // Otras propiedades del lenguaje de programación
    }
}
