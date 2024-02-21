using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class HelloWorld : PageModel
    {
        public IActionResult OnGet()
        {
            if (Request.IsHtmx())
            {
                return Content("<span>Hello, Aboba!</span>", "text/html");
            }
            else
            {
                return Page();
            }
        }
    }
}