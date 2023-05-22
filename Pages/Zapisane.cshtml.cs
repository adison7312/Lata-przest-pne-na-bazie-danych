using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYear.Form;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Net;
using LeapYear.Pages;
using LeapYear.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LeapYear.Pages
{
    public class ZapisaneModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly YearFormContext _yearFormContext;
        public PaginatedList<YearForm> YearForms { get; set; }
        
        public ZapisaneModel(YearFormContext yearFormContext, IConfiguration configuration)
        {
            _yearFormContext = yearFormContext;
            _configuration = configuration;
        }

        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<YearForm> yearNameFormsIQ = from s in _yearFormContext.YearForm select s;

            yearNameFormsIQ = yearNameFormsIQ.OrderByDescending(s => s.Timestamp);

            int pageSize = _configuration.GetValue<int>("PageSize");
            YearForms = await PaginatedList<YearForm>.CreateAsync(
                               yearNameFormsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
