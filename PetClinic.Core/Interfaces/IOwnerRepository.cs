using PetClinic.Core.Entities;

namespace PetClinic.Core.Interfaces;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<IReadOnlyList<Owner>> SearchByLastNameAsync(string lastName);
    Task<Owner?> GetByIdWithPetsAsync(int id);
}
