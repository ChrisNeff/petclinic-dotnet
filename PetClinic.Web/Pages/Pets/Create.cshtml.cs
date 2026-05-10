using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Pets;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;

    public CreateModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Pet Pet { get; set; } = new();

    public SelectList PetTypes { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int ownerId)
    {
        Pet.OwnerId = ownerId;
        PetTypes = new SelectList(await _db.PetTypes.OrderBy(t => t.Name).ToListAsync(), "Id", "Name");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PetTypes = new SelectList(await _db.PetTypes.OrderBy(t => t.Name).ToListAsync(), "Id", "Name");
            return Page();
        }

        _db.Pets.Add(Pet);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Owners/Detail", new { id = Pet.OwnerId });
    }
}
