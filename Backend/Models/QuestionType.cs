using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTSeleccion.Backend.Models
{
public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }
        public string Name {get;set;}

        // Otras propiedades del tipo de pregunta

        public ICollection<Question> Questions { get; set; }
    }
}
