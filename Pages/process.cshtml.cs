using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using PTSeleccion.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace PTSeleccion.Frontend.Pages
{

    public class processModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private Dictionary<string, string> _authenticatedUserInfo;

        private DBContext _dbContext = new DBContext();
        public Process Process { get; private set; }

        public ICollection<Language> langs = new List<Language>();

        public processModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            langs = _dbContext.Languages.ToList();
        }




        public IActionResult OnGet()
        {


            // Lógica adicional...

            return Page();
        }
        

    }
}
