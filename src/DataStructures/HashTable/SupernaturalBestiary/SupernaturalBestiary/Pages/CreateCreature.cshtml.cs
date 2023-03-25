using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupernaturalBestiary.Application.ViewModels;
using SupernaturalBestiary.Data;
using SupernaturalBestiary.Domain.Models;
using SupernaturalBestiary.Entities;
using SupernaturalBestiary.Infastructure.Repositories;

namespace SupernaturalBestiary.Pages
{
    public class CreateCreatureModel : PageModel
    {
        private readonly ICreatureRepository _creatureRepository;

        public CreateCreatureModel(ICreatureRepository creatureRepository)
        {
            _creatureRepository = creatureRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateCreatureViewModel creatureViewModel { get; set; } = default!;
        [BindProperty]
        public Ability Ability { get; set; } = default!;
        [BindProperty]
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid || creatureViewModel == null)
            {
                return Page();
            }
            if (Ability is not null)
            {
                creatureViewModel.Abilities.Add(Ability);
            }
            Hashtable abilities = new Hashtable(creatureViewModel
                    .Abilities
                    .ToDictionary(ability => ability.Name, ability => ability.Description));
            Creature creature = new Creature(abilities)
            {
                Description = creatureViewModel.Description,
                Name = creatureViewModel.Name,
            };
            await _creatureRepository.SaveCreatureAsync(creature);

            return RedirectToPage("./Index");
        }
    }
}
