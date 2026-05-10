using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Pets;

public class EditModel : PageModel
{
    private readonly IRepository<Pet> _pets;
    private readonly IRepository<PetType> _petTypes;

    public EditModel(IRepository<Pet> pets, IRepository<PetType> petTypes)
    {
        _pets = pets;
        _petTypes = petTypes;
    }

    [BindProperty]
    public Pet Pet { get; set; } = null!;

    public SelectList PetTypes { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Pet = await _pets.GetByIdAsync(id) ?? null!;
        if (Pet == null) return NotFound();

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

        await _pets.UpdateAsync(Pet);
        return RedirectToPage("/Owners/Detail", new { id = Pet.OwnerId });
    }
}
