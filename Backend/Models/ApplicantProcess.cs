using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTSeleccion.Backend.Models
{
    public class ApplicantProcess
    {
        [Key]
        public int ApplicantProcessId { get; set; }
        
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public int ProcessId { get; set; }
        public Process Process { get; set; }    

        public int StatusId { get; set; } // Referencia al estado
        public Status Status { get; set; } // Estado

        public decimal? TestResult { get; set; } // Calificación o resultado de la prueba (0 a 100)
        // Otras propiedades de estado si son necesarias

        
    }
}
