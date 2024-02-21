using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class Scroll : PageModel
    {
        [BindProperty(SupportsGet = true)] 
        public int Cursor { get; set; } = 1;
        
        public IActionResult OnGet()
        {
            if (Request.IsHtmx())
            {
                return Partial("_Cards", this);
            }
            else
            {
                return Page();
            }
        }
    }
}