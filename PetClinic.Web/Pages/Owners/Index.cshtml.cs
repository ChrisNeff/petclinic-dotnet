using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Core.Entities;
using PetClinic.Core.Interfaces;

namespace PetClinic.Web.Pages.Owners;

public class IndexModel : PageModel
{
    private readonly IOwnerRepository _owners;

    public IndexModel(IOwnerRepository owners) => _owners = owners;

    public IReadOnlyList<Owner> Owners { get; set; } = [];
    [BindProperty(SupportsGet = true)]
    public string? LastName { get; set; }

    public async Task OnGetAsync()
    {
        Owners = string.IsNullOrWhiteSpace(LastName)
            ? await _owners.ListAsync()
            : await _owners.SearchByLastNameAsync(LastName);
    }
}
