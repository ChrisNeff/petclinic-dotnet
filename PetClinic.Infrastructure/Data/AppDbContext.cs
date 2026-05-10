using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Entities;

namespace PetClinic.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<PetType> PetTypes => Set<PetType>();
    public DbSet<Vet> Vets => Set<Vet>();
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<VetSpecialty> VetSpecialties => Set<VetSpecialty>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VetSpecialty>()
            .HasKey(vs => new { vs.VetId, vs.SpecialtyId });

        modelBuilder.Entity<VetSpecialty>()
            .HasOne(vs => vs.Vet)
            .WithMany(v => v.VetSpecialties)
            .HasForeignKey(vs => vs.VetId);

        modelBuilder.Entity<VetSpecialty>()
            .HasOne(vs => vs.Specialty)
            .WithMany()
            .HasForeignKey(vs => vs.SpecialtyId);

        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Pets)
            .HasForeignKey(p => p.OwnerId);

        modelBuilder.Entity<Pet>()
            .HasOne(p => p.PetType)
            .WithMany()
            .HasForeignKey(p => p.PetTypeId);

        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Pet)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PetId);

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetType>().HasData(
            new PetType { Id = 1, Name = "cat" },
            new PetType { Id = 2, Name = "dog" },
            new PetType { Id = 3, Name = "lizard" },
            new PetType { Id = 4, Name = "snake" },
            new PetType { Id = 5, Name = "bird" },
            new PetType { Id = 6, Name = "hamster" }
        );

        modelBuilder.Entity<Specialty>().HasData(
            new Specialty { Id = 1, Name = "radiology" },
            new Specialty { Id = 2, Name = "surgery" },
            new Specialty { Id = 3, Name = "dentistry" }
        );

        modelBuilder.Entity<Owner>().HasData(
            new Owner { Id = 1, FirstName = "George", LastName = "Franklin", Address = "110 W. Liberty St.", City = "Madison", Telephone = "6085551023" },
            new Owner { Id = 2, FirstName = "Betty",  LastName = "Davis",    Address = "638 Cardinal Ave.",   City = "Sun Prairie", Telephone = "6085551749" },
            new Owner { Id = 3, FirstName = "Eduardo",LastName = "Rodriquez",Address = "2693 Commerce St.",   City = "McFarland",   Telephone = "6085558763" },
            new Owner { Id = 4, FirstName = "Harold", LastName = "Davis",    Address = "563 Friendly St.",    City = "Windsor",     Telephone = "6085553198" },
            new Owner { Id = 5, FirstName = "Peter",  LastName = "McTavish", Address = "2387 S. Fair Way",    City = "Madison",     Telephone = "6085552765" },
            new Owner { Id = 6, FirstName = "Jean",   LastName = "Coleman",  Address = "105 N. Lake St.",     City = "Monona",      Telephone = "6085552654" },
            new Owner { Id = 7, FirstName = "Jeff",   LastName = "Black",    Address = "1450 Oak Blvd.",      City = "Monona",      Telephone = "6085555387" },
            new Owner { Id = 8, FirstName = "Maria",  LastName = "Escobito", Address = "345 Maple St.",       City = "Madison",     Telephone = "6085557683" },
            new Owner { Id = 9, FirstName = "David",  LastName = "Schroeder",Address = "2749 Blackhawk Trail",City = "Windsor",     Telephone = "6085559435" },
            new Owner { Id = 10,FirstName = "Carlos", LastName = "Estaban",  Address = "2335 Independence La.",City = "Waunakee",  Telephone = "6085555487" }
        );

        modelBuilder.Entity<Pet>().HasData(
            new Pet { Id = 1,  Name = "Leo",      BirthDate = new DateOnly(2010, 9, 7),  OwnerId = 1,  PetTypeId = 2 },
            new Pet { Id = 2,  Name = "Basil",    BirthDate = new DateOnly(2012, 8, 6),  OwnerId = 2,  PetTypeId = 6 },
            new Pet { Id = 3,  Name = "Rosy",     BirthDate = new DateOnly(2011, 4, 17), OwnerId = 3,  PetTypeId = 2 },
            new Pet { Id = 4,  Name = "Jewel",    BirthDate = new DateOnly(2010, 3, 7),  OwnerId = 3,  PetTypeId = 2 },
            new Pet { Id = 5,  Name = "Iggy",     BirthDate = new DateOnly(2010, 11, 30),OwnerId = 4,  PetTypeId = 3 },
            new Pet { Id = 6,  Name = "George",   BirthDate = new DateOnly(2010, 1, 20), OwnerId = 5,  PetTypeId = 4 },
            new Pet { Id = 7,  Name = "Samantha",  BirthDate = new DateOnly(2012, 9, 4), OwnerId = 6,  PetTypeId = 1 },
            new Pet { Id = 8,  Name = "Max",      BirthDate = new DateOnly(2012, 9, 4),  OwnerId = 6,  PetTypeId = 1 },
            new Pet { Id = 9,  Name = "Lucky",    BirthDate = new DateOnly(2011, 8, 6),  OwnerId = 7,  PetTypeId = 5 },
            new Pet { Id = 10, Name = "Mulligan", BirthDate = new DateOnly(2007, 2, 24), OwnerId = 8,  PetTypeId = 2 },
            new Pet { Id = 11, Name = "Freddy",   BirthDate = new DateOnly(2010, 3, 9),  OwnerId = 9,  PetTypeId = 5 },
            new Pet { Id = 12, Name = "Lucky",    BirthDate = new DateOnly(2010, 6, 24), OwnerId = 10, PetTypeId = 2 },
            new Pet { Id = 13, Name = "Sly",      BirthDate = new DateOnly(2012, 6, 8),  OwnerId = 10, PetTypeId = 1 }
        );

        modelBuilder.Entity<Vet>().HasData(
            new Vet { Id = 1, FirstName = "James",   LastName = "Carter"   },
            new Vet { Id = 2, FirstName = "Helen",   LastName = "Leary"    },
            new Vet { Id = 3, FirstName = "Linda",   LastName = "Douglas"  },
            new Vet { Id = 4, FirstName = "Rafael",  LastName = "Ortega"   },
            new Vet { Id = 5, FirstName = "Henry",   LastName = "Stevens"  },
            new Vet { Id = 6, FirstName = "Sharon",  LastName = "Jenkins"  }
        );

        modelBuilder.Entity<VetSpecialty>().HasData(
            new VetSpecialty { VetId = 2, SpecialtyId = 1 },
            new VetSpecialty { VetId = 3, SpecialtyId = 2 },
            new VetSpecialty { VetId = 3, SpecialtyId = 3 },
            new VetSpecialty { VetId = 4, SpecialtyId = 2 },
            new VetSpecialty { VetId = 5, SpecialtyId = 1 }
        );

        modelBuilder.Entity<Visit>().HasData(
            new Visit { Id = 1, PetId = 7,  VisitDate = new DateOnly(2013, 1, 1),  Description = "rabies shot" },
            new Visit { Id = 2, PetId = 8,  VisitDate = new DateOnly(2013, 1, 2),  Description = "rabies shot" },
            new Visit { Id = 3, PetId = 8,  VisitDate = new DateOnly(2013, 1, 3),  Description = "neutered"    },
            new Visit { Id = 4, PetId = 7,  VisitDate = new DateOnly(2013, 1, 4),  Description = "spayed"      }
        );
    }
}
