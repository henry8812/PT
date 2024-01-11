using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using PTSeleccion.Backend.Models;

namespace PTSeleccion.Backend.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public QuestionController(IConfiguration configuration, DBContext dbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("all")]
        public IActionResult GetQuestions()
        {
            var questions = _dbContext.Questions.ToList();
            return Ok(questions);
        }

        [HttpGet("process/{id}")]
        public IActionResult GetProcessQuestions(int id)
        {
            var process = _dbContext.Processes
                                    .Include(p => p.Questions) // Asegúrate de incluir las preguntas
                                    .FirstOrDefault(p => p.ProcessId == id);

            if (process == null)
            {
                return NotFound($"Process with ID {id} not found");
            }

            foreach (var question in process.Questions)
            {
                question.Processes = null; // Romper la referencia circular
            }

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var questionsJson = JsonConvert.SerializeObject(process.Questions, Formatting.Indented, settings);
            return Ok(questionsJson);
        }


        [HttpPost("create")]
        public IActionResult CreateQuestion([FromBody] QuestionCreationModel questionModel)
        {
            if (!ModelState.IsValid || questionModel == null || questionModel.Question == null)
            {
                return BadRequest("Invalid data");
            }

            var newQuestion = new Question
            {
                Text = questionModel.Question.Text,
                // ... mapear otras propiedades
            };

            _dbContext.Questions.Add(newQuestion);
            _dbContext.SaveChanges();
            Process? resp = null;
            if (questionModel.ProcessId != null)
            {
                var process = _dbContext.Processes.FirstOrDefault(p => p.ProcessId == questionModel.ProcessId);
                resp = process;
                if (process != null)
                {
                    process.Questions = process.Questions ?? new List<Question>();
                    process.Questions.Add(newQuestion);
                    _dbContext.SaveChanges();
                }
            }



            return Ok(resp.ProcessId);
        }
    }
}
