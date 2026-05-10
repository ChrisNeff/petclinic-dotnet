using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Pets;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;

    public EditModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Pet Pet { get; set; } = null!;

    public SelectList PetTypes { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Pet = await _db.Pets.FindAsync(id) ?? null!;
        if (Pet == null) return NotFound();
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

        _db.Entry(Pet).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return RedirectToPage("/Owners/Detail", new { id = Pet.OwnerId });
    }
}
