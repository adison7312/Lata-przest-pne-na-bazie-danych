using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYear.Form;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;

namespace LeapYear.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ILogger<IndexModel> _logger;
        private readonly YearFormContext _context;

        [BindProperty]

        public YearForm YearForm { get; set; }
        public IList<YearForm> YearForms { get; set; }


        public IndexModel(ILogger<IndexModel> logger, YearFormContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        
        public IActionResult OnPost()
        {
            YearForms = _context.YearForm.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.YearForm.Add(YearForm);
            _context.SaveChanges();
            return Page();
        }


    }
}