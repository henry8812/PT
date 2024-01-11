using System.ComponentModel.DataAnnotations;

namespace PTSeleccion.Backend.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public ICollection<Option> Options { get; set; }
        // Otras propiedades de la respuesta

        // Relación con Question
        public Question Question { get; set; }
        // Relación con Evaluation
   
        // Otras propiedades de Evaluación
    }
}