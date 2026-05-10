using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Visits;

public class CreateModel : PageModel
{
    private readonly IRepository<Visit> _visits;
    private readonly IRepository<Pet> _pets;

    public CreateModel(IRepository<Visit> visits, IRepository<Pet> pets)
    {
        _visits = visits;
        _pets = pets;
    }

    [BindProperty]
    public Visit Visit { get; set; } = new();

    public string PetName { get; set; } = string.Empty;
    public int OwnerId { get; set; }

    public async Task<IActionResult> OnGetAsync(int petId)
    {
        var pet = await _pets.GetByIdAsync(petId);
        if (pet == null) return NotFound();

        Visit.PetId = petId;
        Visit.VisitDate = DateOnly.FromDateTime(DateTime.Today);
        PetName = pet.Name;
        OwnerId = pet.OwnerId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var pet = await _pets.GetByIdAsync(Visit.PetId);
            PetName = pet?.Name ?? string.Empty;
            OwnerId = pet?.OwnerId ?? 0;
            return Page();
        }

        await _visits.AddAsync(Visit);

        var petForRedirect = await _pets.GetByIdAsync(Visit.PetId);
        return RedirectToPage("/Owners/Detail", new { id = petForRedirect?.OwnerId });
    }
}
