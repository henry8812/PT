using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTSeleccion.Backend.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace PTSeleccion.Backend.Controllers
{


    [ApiController]
    [Route("language")]
    public class LanguageController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public LanguageController()
        {
            Console.WriteLine("entro al controller de JOBS");

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json"); // Nombre del archivo de configuración

            _configuration = builder.Build();
            _dbContext = new DBContext();
        }

        [HttpGet ("all")]
        public IActionResult CreateProcess()
        {
      


            // Añadir el nuevo proceso al contexto
            var langs = _dbContext.Processes.ToList();

            // Guardar cambios en la base de datos
        

            return Ok(langs);
        }


    }
}
