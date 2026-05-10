namespace PetClinic.Core.Entities;

public class Visit
{
    public int Id { get; set; }
    public DateOnly VisitDate { get; set; }
    public string Description { get; set; } = string.Empty;

    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;
}
