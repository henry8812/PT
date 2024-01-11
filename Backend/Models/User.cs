using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PTSeleccion.Backend.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Document { get; set; }

        // Relación con pruebas de selección
        public Applicant Applicant { get; set; }


        // Otras propiedades específicas si es necesario
    }

}
