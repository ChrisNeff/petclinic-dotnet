using PetClinic.Core.Entities;

namespace PetClinic.Core.Interfaces;

public interface IVetRepository : IRepository<Vet>
{
    Task<IReadOnlyList<Vet>> ListWithSpecialtiesAsync();
}
