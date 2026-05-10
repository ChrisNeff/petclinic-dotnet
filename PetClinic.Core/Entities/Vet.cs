namespace PetClinic.Core.Entities;

public class Vet : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<VetSpecialty> VetSpecialties { get; set; } = new List<VetSpecialty>();

    public string FullName => $"{FirstName} {LastName}";
}
