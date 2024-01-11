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
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;


namespace PTSeleccion.Backend.Controllers
{


    [ApiController]
    [Route("process")]
    public class ProcessesController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public ProcessesController()
        {
            Console.WriteLine("entro al controller de JOBS");

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json"); // Nombre del archivo de configuración

            _configuration = builder.Build();
            _dbContext = new DBContext();
        }

        [HttpPost("create")]
        public IActionResult CreateProcess([FromBody] Process processViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            // Mapear el ViewModel a la entidad de proceso
            var newProcess = new Process
            {
                Name = processViewModel.Name,
                Description = processViewModel.Description,
                StartDate = processViewModel.StartDate,
                EndDate = processViewModel.EndDate,
                Questions = new List<Question>(),
                ApplicantProcesses = new List<ApplicantProcess>(),
                LanguageId = processViewModel.LanguageId
                // ... mapear otras propiedades
            };

            // Añadir el nuevo proceso al contexto
            _dbContext.Processes.Add(newProcess);

            // Guardar cambios en la base de datos
            _dbContext.SaveChanges();

            return Ok(newProcess);
        }
[HttpGet("all2")]
        public IActionResult GetProcesses()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // Opcional, para una salida más legible en JSON
            };

          var processes = _dbContext.Processes
    .Include(p => p.ApplicantProcesses) // Cargar explícitamente la relación ApplicantProcesses
    .ToList();


            return Ok(System.Text.Json.JsonSerializer.Serialize(processes, options));
        }

[HttpGet("all")]
public IActionResult GetProcesses2()
{
    var settings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        Formatting = Formatting.Indented
    };

 var processes = _dbContext.Processes
        .Include(p => p.Language)
        .Include(p => p.Questions)
        .Include(p => p.ApplicantProcesses)
        
            .ThenInclude(a => a.Applicant)
                .ThenInclude(applicant => applicant.User)
        .Include(p => p.TestType)  // Incluye la propiedad TestType
        .Include(p => p.Level) 
        .ToList();
       var simplifiedProcesses = processes.Select(p => new
    {
        p.ProcessId,
        p.Name,
        p.Description,
        p.StartDate,
        p.EndDate,
        p.TestType,
        p.NumberOfQuestions,
        p.Level,
        Language = new
        {
            p.Language.LanguageId,
            p.Language.Name,
            // Incluir otras propiedades de Language que necesites
        },
        p.Questions,
        p.ApplicantProcesses
    }).ToList();

    var json = JsonConvert.SerializeObject(simplifiedProcesses, settings);

    return Ok(json);
}
    }
}