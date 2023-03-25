using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupernaturalBestiary.Data;
using SupernaturalBestiary.Entities;

namespace SupernaturalBestiary.Pages
{
    public class CreatureListModel : PageModel
    {
        private readonly SupernaturalBestiary.Data.CreatureDbContext _context;

        public CreatureListModel(SupernaturalBestiary.Data.CreatureDbContext context)
        {
            _context = context;
        }

        public IList<CreatureEntity> CreatureEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Creatures != null)
            {
                CreatureEntity = await _context.Creatures.ToListAsync();
            }
        }
    }
}
