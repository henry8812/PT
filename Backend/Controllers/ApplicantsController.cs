using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTSeleccion.Backend.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.ObjectPool;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace PTSeleccion.Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ApplicantsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public ApplicantsController(

            IConfiguration configuration,
            DBContext dbContext)
        {

            _configuration = configuration;
            _dbContext = dbContext;
        }


        [HttpGet("all")]
        public IActionResult GetApplicants()
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var applicants = _dbContext.Applicants
                   .Include(p => p.User)
                   .Include(p => p.ApplicantProcesses)
                   .ToList();
            var simplifiedProcesses = applicants.Select(p => new
            {
                p.ApplicantId,
                User = new
                {
                    p.User.UserName,
                    p.User.FirstName,
                    
                    p.User.LastName,
                    p.User.Document,
                    p.User.Email
                },
                ApplicantProcesses = p.ApplicantProcesses.Select(ap => new
                {
                    ap.ApplicantProcessId,
                    ap.ProcessId // Agrega aquí otras propiedades que desees incluir
                }).ToList()
            }).ToList();

            var json = JsonConvert.SerializeObject(simplifiedProcesses, settings);

            return Ok(json);
        }
    }
}