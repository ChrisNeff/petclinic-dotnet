using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PetTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VetSpecialties",
                columns: table => new
                {
                    VetId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialtyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetSpecialties", x => new { x.VetId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_VetSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VetSpecialties_Vets_VetId",
                        column: x => x.VetId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VisitDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Telephone" },
                values: new object[,]
                {
                    { 1, "110 W. Liberty St.", "Madison", "George", "Franklin", "6085551023" },
                    { 2, "638 Cardinal Ave.", "Sun Prairie", "Betty", "Davis", "6085551749" },
                    { 3, "2693 Commerce St.", "McFarland", "Eduardo", "Rodriquez", "6085558763" },
                    { 4, "563 Friendly St.", "Windsor", "Harold", "Davis", "6085553198" },
                    { 5, "2387 S. Fair Way", "Madison", "Peter", "McTavish", "6085552765" },
                    { 6, "105 N. Lake St.", "Monona", "Jean", "Coleman", "6085552654" },
                    { 7, "1450 Oak Blvd.", "Monona", "Jeff", "Black", "6085555387" },
                    { 8, "345 Maple St.", "Madison", "Maria", "Escobito", "6085557683" },
                    { 9, "2749 Blackhawk Trail", "Windsor", "David", "Schroeder", "6085559435" },
                    { 10, "2335 Independence La.", "Waunakee", "Carlos", "Estaban", "6085555487" }
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "cat" },
                    { 2, "dog" },
                    { 3, "lizard" },
                    { 4, "snake" },
                    { 5, "bird" },
                    { 6, "hamster" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "radiology" },
                    { 2, "surgery" },
                    { 3, "dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Vets",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "James", "Carter" },
                    { 2, "Helen", "Leary" },
                    { 3, "Linda", "Douglas" },
                    { 4, "Rafael", "Ortega" },
                    { 5, "Henry", "Stevens" },
                    { 6, "Sharon", "Jenkins" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Name", "OwnerId", "PetTypeId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2010, 9, 7), "Leo", 1, 2 },
                    { 2, new DateOnly(2012, 8, 6), "Basil", 2, 6 },
                    { 3, new DateOnly(2011, 4, 17), "Rosy", 3, 2 },
                    { 4, new DateOnly(2010, 3, 7), "Jewel", 3, 2 },
                    { 5, new DateOnly(2010, 11, 30), "Iggy", 4, 3 },
                    { 6, new DateOnly(2010, 1, 20), "George", 5, 4 },
                    { 7, new DateOnly(2012, 9, 4), "Samantha", 6, 1 },
                    { 8, new DateOnly(2012, 9, 4), "Max", 6, 1 },
                    { 9, new DateOnly(2011, 8, 6), "Lucky", 7, 5 },
                    { 10, new DateOnly(2007, 2, 24), "Mulligan", 8, 2 },
                    { 11, new DateOnly(2010, 3, 9), "Freddy", 9, 5 },
                    { 12, new DateOnly(2010, 6, 24), "Lucky", 10, 2 },
                    { 13, new DateOnly(2012, 6, 8), "Sly", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "VetSpecialties",
                columns: new[] { "SpecialtyId", "VetId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 2, 4 },
                    { 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Description", "PetId", "VisitDate" },
                values: new object[,]
                {
                    { 1, "rabies shot", 7, new DateOnly(2013, 1, 1) },
                    { 2, "rabies shot", 8, new DateOnly(2013, 1, 2) },
                    { 3, "neutered", 8, new DateOnly(2013, 1, 3) },
                    { 4, "spayed", 7, new DateOnly(2013, 1, 4) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VetSpecialties_SpecialtyId",
                table: "VetSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PetId",
                table: "Visits",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VetSpecialties");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "PetTypes");
        }
    }
}
