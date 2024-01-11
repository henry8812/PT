using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTSeleccion.Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace PTSeleccion.Frontend.Pages
{
    public class ProcessDetailsModel : PageModel
    {
        private readonly DBContext _dbContext;

        public ProcessDetailsModel(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Question> questions { get; private set; } = new List<Question>();
        public ICollection<ApplicantProcess> applicants { get; private set; } = new List<ApplicantProcess>();

        public ICollection<Question> Noquestions { get; private set; } = new List<Question>();
        public ICollection<Applicant> Noapplicants { get; private set; } = new List<Applicant>();

        

        public Process Process { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Process = await _dbContext.Processes
                .Include(p => p.Questions)
                .Include(p => p.ApplicantProcesses)
                    .ThenInclude(ap => ap.Applicant)
                        .ThenInclude(a => a.User)
                .FirstOrDefaultAsync(m => m.ProcessId == id);

            if (Process == null)
            {
                return NotFound();
            }

            questions = Process.Questions.ToList();
            applicants = Process.ApplicantProcesses.ToList();

    
    // Obtener solicitantes sin proceso asociado al proceso actual
    Noapplicants = _dbContext.Applicants.ToList(); // Suponiendo que Applicants es DbSet en tu DbContext



            return Page();
        }
    }
}
