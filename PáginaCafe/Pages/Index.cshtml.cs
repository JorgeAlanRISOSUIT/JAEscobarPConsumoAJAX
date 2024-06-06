using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PáginaCafe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ML.DTO.PersonaAseguradoraDTO Asegurado { get; set; }

        [BindProperty]
        public int dia { get; set; }

        [BindProperty]
        public int mes { get; set; }

        [BindProperty]
        public int year { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
