using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exercises.Pages
{
    public class Selects : PageModel
    {
        private readonly Dictionary<string, List<string>> cuisines =
            new()
            {
                {"Krololian", new List<string> {"Krolburger", "Hot krolls", "Krollbeque"}},
                {"Abobian", new List<string> {"Spaghetti", "Pizza", "Lasagna"}},
                {"Lumbexican", new List<string> {"Tacos", "Enchiladas", "Churros"}},
                {"Booberican", new List<string> {"Burgers", "Hot dogs", "Barbeque"}}
            };

        public IList<SelectListItem> CuisineItems
        {
            get
            {
                var items = cuisines.Keys
                    .Select(c => new SelectListItem(c, c))
                    .ToList();

                items.Insert(0, new SelectListItem("Choose an option", "") {
                    Disabled = true,
                    Selected = true
                });

                return items;
            }
        }

        // Step #1
        // TODO: Add string? parameters Cuisine and Food
        // hint: don't forget BindProperty
        [BindProperty(SupportsGet = true)]
        public string? Cuisine { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Food { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnGetFoods()
        {
            var html = new StringBuilder();

            // Step #2
            // Todo: Generate Options for Select Element
            // hint: use the selected cuisine to get the 

            #region Selection logic 

            if (Cuisine is { Length: > 0 } cuisine && cuisines.TryGetValue(cuisine, out var foods))
            {
                html.AppendLine("<option disabled selected>Select a food</option>");
                foreach (var food in foods)
                {
                    html.AppendLine($"<option>{food}</option>");
                }
            }

            #endregion

            return Content(html.ToString(), "text/html");
        }

        public IActionResult OnGetLove()
        {
            // Step 3
            // Todo: Return Span proclaiming your love for Food
            // hint: <span><i class=\"fa fa-heart\"></i> I love {Food}!</span>
            
            return Content($"<span><i class=\"fa fa-heart\"></i> I love {Food}!</span>");
        }
    }
}