using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using PTSeleccion.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace PTSeleccion.Frontend.Pages
{

    public class ApplicantsModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly List<Applicant> applicants;

        private DBContext _dbContext = new DBContext();
        public ApplicantsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            applicants = _dbContext.Applicants.ToList();
        }




        public IActionResult OnGet()
        {


            // Lógica adicional...

            return Page();
        }
        

    }
}
