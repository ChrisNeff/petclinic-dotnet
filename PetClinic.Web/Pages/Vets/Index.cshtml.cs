using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Vets;

public class IndexModel : PageModel
{
    private readonly IVetRepository _vets;

    public IndexModel(IVetRepository vets) => _vets = vets;

    public IReadOnlyList<Vet> Vets { get; set; } = [];

    public async Task OnGetAsync() =>
        Vets = await _vets.ListWithSpecialtiesAsync();
}
