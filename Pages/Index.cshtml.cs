using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using PTSeleccion.Backend.Models;

namespace PTSeleccion.Frontend.Pages
{

    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private Dictionary<string, string> _authenticatedUserInfo;

        private DBContext _dbContext = new DBContext();

        public ICollection<Language> langs = new List<Language>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            langs = _dbContext.Languages.ToList();
        }


        public IActionResult OnGet()
        {

            return RedirectToPage("/process");
        }

    }
}
