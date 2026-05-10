using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;
using PetClinic.Infrastructure.Data;

namespace PetClinic.Web.Pages.Vets;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db) => _db = db;

    public IReadOnlyList<Vet> Vets { get; set; } = [];

    public async Task OnGetAsync()
    {
        Vets = await _db.Vets
            .Include(v => v.VetSpecialties)
                .ThenInclude(vs => vs.Specialty)
            .OrderBy(v => v.LastName)
            .ToListAsync();
    }
}
