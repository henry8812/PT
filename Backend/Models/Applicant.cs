using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PTSeleccion.Backend.Models
{
   public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        // Datos adicionales del aspirante
        
        // Relación con User
        [ForeignKey("User")]
        public int UserId { get; set; } // Clave foránea a User

        // Relación con User
        public User User { get; set; }

        // Relación con pruebas de selección y estado
        public ICollection<ApplicantProcess> ApplicantProcesses { get; set; } // Relación con las pruebas y su estado

        // Otras propiedades específicas si es necesario
    }
}
