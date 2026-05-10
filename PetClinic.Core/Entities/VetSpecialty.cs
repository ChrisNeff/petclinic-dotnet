namespace PetClinic.Core.Entities;

public class VetSpecialty
{
    public int VetId { get; set; }
    public Vet Vet { get; set; } = null!;

    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; } = null!;
}
