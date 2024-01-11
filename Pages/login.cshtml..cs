using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PTSeleccion.Frontend.Pages
{
    public struct UserData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        // Otras propiedades del usuario si son necesarias
    }

    public class LoginPage : PageModel
    {
        public readonly HttpClient _httpClient;
        public string Username;
        public string Password;



        public void OnGet()
        {
            // Acciones cuando se carga la página de inicio de sesión
            Console.WriteLine("entro a login GET");
        }

    }
}

