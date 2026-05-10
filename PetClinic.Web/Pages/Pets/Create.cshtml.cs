using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Pets;

public class CreateModel : PageModel
{
    private readonly IRepository<Pet> _pets;
    private readonly IRepository<PetType> _petTypes;

    public CreateModel(IRepository<Pet> pets, IRepository<PetType> petTypes)
    {
        _pets = pets;
        _petTypes = petTypes;
    }

    [BindProperty]
    public Pet Pet { get; set; } = new();

    public SelectList PetTypes { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int ownerId)
    {
        Pet.OwnerId = ownerId;
        var types = await _petTypes.ListAsync();
        PetTypes = new SelectList(types.OrderBy(t => t.Name), "Id", "Name");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var types = await _petTypes.ListAsync();
            PetTypes = new SelectList(types.OrderBy(t => t.Name), "Id", "Name");
            return Page();
        }

        await _pets.AddAsync(Pet);
        return RedirectToPage("/Owners/Detail", new { id = Pet.OwnerId });
    }
}
