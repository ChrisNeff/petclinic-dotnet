namespace PetClinic.Core.Entities;

public class Pet : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; } = null!;

    public int PetTypeId { get; set; }
    public PetType PetType { get; set; } = null!;

    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
