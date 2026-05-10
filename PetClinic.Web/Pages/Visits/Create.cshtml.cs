using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Visits;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;

    public CreateModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Visit Visit { get; set; } = new();

    public string PetName { get; set; } = string.Empty;
    public int OwnerId { get; set; }

    public async Task<IActionResult> OnGetAsync(int petId)
    {
        var pet = await _db.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == petId);
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
            var pet = await _db.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == Visit.PetId);
            PetName = pet?.Name ?? string.Empty;
            OwnerId = pet?.OwnerId ?? 0;
            return Page();
        }

        _db.Visits.Add(Visit);
        await _db.SaveChangesAsync();

        var petForRedirect = await _db.Pets.FindAsync(Visit.PetId);
        return RedirectToPage("/Owners/Detail", new { id = petForRedirect?.OwnerId });
    }
}
