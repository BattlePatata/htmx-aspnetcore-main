using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercises.Pages
{
    public class Tabs : PageModel
    {
        public IEnumerable<string> Items { get; }
            = new[] {"First", "Second", "Third"};
        
        [BindProperty(Name = "tab", SupportsGet = true)]
        public string? Tab { get; set; }

        public bool IsSelected(string name) => 
            name.Equals(Tab?.Trim(), StringComparison.OrdinalIgnoreCase);

        public string? IsSelectedCss(string tab, string? cssClass)
            => IsSelected(tab) ? cssClass : null;

        public IActionResult OnGet()
        {
            // make sure we have a tab
            Tab = Items.Any(IsSelected) ? Tab : Items.First();
            
            if (Request.IsHtmx())
            {
                return Partial("_Tabs", this);
            }
            else
            {
                return Page();
            }
        }
    }
}