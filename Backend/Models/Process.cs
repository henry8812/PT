using System;
using System.Collections.Generic;

namespace PTSeleccion.Backend.Models
{
    public class Process
    {
        public int ProcessId { get; set; }
        public string Name { get; set; } // Nombre de la prueba
        public string Description { get; set; } // Descripción de la prueba
        public DateTime StartDate { get; set; } // Fecha de inicio de la prueba
        public DateTime EndDate { get; set; } // Fecha de finalización de la prueba

        public int? TestTypeId { get; set; } // Referencia al tipo de prueba
        public TestType? TestType { get; set; } // Tipo de prueba

        public int LanguageId { get; set; } // Id del lenguaje de programación de la prueba
        public Language Language {get;set;}
        public int NumberOfQuestions { get; set; } // Cantidad de preguntas

        public int? LevelId { get; set; } // Referencia al nivel de la prueba
        public Level? Level { get; set; } // Nivel de la prueba

        // Relación con preguntas
        public ICollection<Question>? Questions { get; set; } // Preguntas asignadas a esta prueba

        // Relación con aspirantes
        public ICollection<ApplicantProcess> ApplicantProcesses { get; set; }

        // Otras propiedades de la prueba
    }
}
