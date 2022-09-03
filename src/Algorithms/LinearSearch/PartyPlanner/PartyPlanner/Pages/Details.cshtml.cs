using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PartyPlanner.Data;
using PartyPlanner.Features.Parties.Models;

namespace PartyPlanner.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly PartyPlanner.Data.ApplicationDbContext _context;

        public DetailsModel(PartyPlanner.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Party Party { get; set; } = default!;
        /// <summary>
        /// Gets a part by id
        /// This serves as an example of a linear search because while the basic overload for First isn't exactly a linear search
        /// The predicate overload is a linear search
        /// https://referencesource.microsoft.com/#System.Core/System/Linq/Enumerable.cs,8087366974af11d2
        /// https://www.programming-free.com/2012/07/c-list-linear-search-vs-binary-search.html
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Parties == null)
            {
                return NotFound();
            }
            // https://referencesource.microsoft.com/#System.Core/System/Linq/Enumerable.cs,8087366974af11d2
            var party = await _context.Parties.FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }
            else 
            {
                Party = party;
            }
            return Page();
        }
    }
}
