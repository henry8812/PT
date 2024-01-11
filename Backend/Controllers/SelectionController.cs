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
    public class SelectionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public SelectionsController(

            IConfiguration configuration,
            DBContext dbContext)
        {

            _configuration = configuration;
            _dbContext = dbContext;
        }


[HttpGet("all")]
public IActionResult GetSelections()
{
    var settings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        Formatting = Formatting.Indented
    };

    var selections = _dbContext.ApplicantProcess
           .Include(ap => ap.Applicant)
               .ThenInclude(a => a.User)
           .Include(ap => ap.Status)
           .Include(ap => ap.Process)
               .ThenInclude(p => p.Level)
           .ToList();

    var simplifiedProcesses = selections.Select(ap => new
    {
        Id = ap.ApplicantProcessId,
        Status = new
        {
            ap.Status?.StatusId,
            ap.Status?.Name
        },
        TestResult = ap.TestResult,
        Applicant = new
        {
            ap.ApplicantId,
            User = new
            {
                ap.Applicant?.User?.UserName,
                ap.Applicant?.User?.FirstName,
                ap.Applicant?.User?.LastName,
                ap.Applicant?.User?.Document,
                ap.Applicant?.User?.Email
            }
        },
        Process = new
        {
            ap.ProcessId,
            ap.Process?.Name,
            Level = new
            {
                ap.Process?.Level?.LevelId,
                ap.Process?.Level?.Name
            }
        }
        // Agrega aquí otras propiedades que desees incluir
    }).ToList();

    var json = JsonConvert.SerializeObject(simplifiedProcesses, settings);

    return Ok(json);
}

    }
}