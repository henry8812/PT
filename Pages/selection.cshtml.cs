using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using PTSeleccion.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace PTSeleccion.Frontend.Pages
{

    public class SelectionModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        public List<ApplicantProcess> selections;

        private DBContext _dbContext = new DBContext();
        public SelectionModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }




        public IActionResult OnGet()
        {


            // Lógica adicional...

            return Page();
        }
        

    }
}
