using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PTSeleccion.Backend.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string Text { get; set; } // Texto de la pregunta
        public string? Category { get; set; } // Categoría de la pregunta
        public string? Difficulty { get; set; } // Dificultad de la pregunta (fácil, medio, difícil)

    [JsonIgnore]

        public ICollection<Process> Processes { get; set; } // Procesos que incluyen esta pregunta
    }
    public class QuestionCreationModel
    {
        public QuestionViewModel Question { get; set; }
        public int? ProcessId { get; set; }
    }
    public class QuestionViewModel
    {
        public string Text { get; set; }
        // Otros campos de la pregunta
    }
}
