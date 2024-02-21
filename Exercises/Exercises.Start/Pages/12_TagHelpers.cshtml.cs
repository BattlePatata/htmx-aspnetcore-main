using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class TagHelpers : PageModel
    {
        public IActionResult OnGet()
        {
            if (Request.IsHtmx())
            {
                return Content("<span>Hello there, General Kenobi. Made with Tag Helpers", "text/html");
            }
        return Page();
        }
    }
}