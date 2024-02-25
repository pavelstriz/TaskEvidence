using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskEvidence.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Orderer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Solver = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAttachments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskChecklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskChecklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskChecklist_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMessages_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "desc1", "BORS Holding", 1 },
                    { 2, "desc2", "BORS Service", 1 },
                    { 3, "desc3", "BORS Logistics", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Company", "Deadline", "Description", "DoneAt", "Orderer", "Priority", "PublishedAt", "Solver", "State", "Status" },
                values: new object[,]
                {
                    { 1, "BORS Holding", new DateTime(2024, 3, 1, 23, 59, 59, 0, DateTimeKind.Unspecified), "Vytvoření systému pro evidenci úkolů", new DateTime(2024, 2, 23, 20, 12, 40, 418, DateTimeKind.Unspecified), "Honza Novák", 1, new DateTime(2024, 2, 23, 19, 27, 24, 609, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 2, "BORS Holding", new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidání javascriptu pro zvýraznění selectu v tabulce", new DateTime(2024, 2, 23, 20, 7, 30, 807, DateTimeKind.Unspecified), "Josef Dvořák", 3, new DateTime(2024, 2, 23, 19, 28, 13, 861, DateTimeKind.Unspecified), "Honza Novák", 1, 1 },
                    { 3, "BORS Holding", new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidání css stylu pro grid", new DateTime(2024, 2, 23, 20, 7, 35, 831, DateTimeKind.Unspecified), "Pavel Stříž", 3, new DateTime(2024, 2, 23, 19, 29, 7, 762, DateTimeKind.Unspecified), "Honza Novák", 1, 1 },
                    { 4, "BORS Service", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Upravení logiky pro zápis Deadline", null, "Pavel Stříž", 2, new DateTime(2024, 2, 23, 19, 32, 13, 919, DateTimeKind.Unspecified), "Josef Dvořák", 1, 2 },
                    { 5, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přejmenování sloupce v databázi", null, "Josef Dvořák", 1, new DateTime(2024, 2, 23, 19, 33, 24, 150, DateTimeKind.Unspecified), "Pavel Stříž", 1, 2 },
                    { 6, "BORS Logistics", new DateTime(2024, 2, 26, 23, 59, 59, 0, DateTimeKind.Unspecified), "Upravení datového typu sloupce v databázi.", new DateTime(2024, 2, 23, 20, 8, 16, 719, DateTimeKind.Unspecified), "Pavel Stříž", 1, new DateTime(2024, 2, 23, 19, 35, 28, 9, DateTimeKind.Unspecified), "Josef Dvořák", 1, 1 },
                    { 7, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Vytvoření pohledů", new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), "Honza Novák", 1, new DateTime(2024, 2, 23, 19, 38, 48, 432, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 8, "BORS Holding", new DateTime(2024, 2, 27, 23, 59, 59, 0, DateTimeKind.Unspecified), "Discard Feature", null, "Pavel Stříž", 1, new DateTime(2024, 2, 23, 19, 42, 10, 842, DateTimeKind.Unspecified), "Honza Novák", 1, 2 },
                    { 9, "BORS Holding", new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Změna tagů", null, "Josef Dvořák", 1, new DateTime(2024, 2, 23, 19, 43, 27, 900, DateTimeKind.Unspecified), "Pavel Stříž", 1, 3 },
                    { 10, "BORS Holding", new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Implementace komunikace formou chatu", new DateTime(2024, 2, 23, 20, 9, 0, 380, DateTimeKind.Unspecified), "Honza Novák", 1, new DateTime(2024, 2, 23, 19, 51, 8, 242, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 11, "BORS Service", new DateTime(2024, 2, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), "Rozdělení kódu", new DateTime(2024, 2, 23, 20, 9, 19, 487, DateTimeKind.Unspecified), "Honza Novák", 1, new DateTime(2024, 2, 23, 19, 53, 10, 937, DateTimeKind.Unspecified), "Josef Dvořák", 1, 1 },
                    { 12, "BORS Holding", new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Oprava chyb při komunikaci client-server", new DateTime(2024, 2, 23, 20, 9, 39, 884, DateTimeKind.Unspecified), "Josef Dvořák", 1, new DateTime(2024, 2, 23, 19, 56, 1, 268, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 13, "BORS Logistics", new DateTime(2024, 2, 27, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidání validací polí na frontendu", null, "Josef Dvořák", 1, new DateTime(2024, 2, 23, 19, 57, 1, 64, DateTimeKind.Unspecified), "Honza Novák", 2, 2 },
                    { 14, "BORS Logistics", new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidání validací polí na frontendu", null, "Pavel Stříž", 1, new DateTime(2024, 2, 23, 19, 58, 4, 53, DateTimeKind.Unspecified), "Honza Novák", 1, 2 },
                    { 15, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidat script pro simulaci dat", new DateTime(2024, 2, 23, 20, 10, 23, 605, DateTimeKind.Unspecified), "Honza Novák", 3, new DateTime(2024, 2, 23, 20, 0, 13, 893, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 16, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Možnost přidání přílohy", null, "Pavel Stříž", 3, new DateTime(2024, 2, 23, 20, 1, 58, 293, DateTimeKind.Unspecified), "Honza Novák", 1, 2 },
                    { 17, "BORS Holding", new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), "Refaktoring jednotlivých částí kódu.", new DateTime(2024, 2, 23, 20, 10, 39, 579, DateTimeKind.Unspecified), "Honza Novák", 1, new DateTime(2024, 2, 23, 20, 2, 40, 263, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 18, "BORS Holding", new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Vytvoření unit testů", null, "Pavel Stříž", 1, new DateTime(2024, 2, 23, 20, 5, 52, 375, DateTimeKind.Unspecified), "Josef Dvořák", 1, 2 },
                    { 19, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Regresní testy", null, "Pavel", 1, new DateTime(2024, 2, 23, 23, 10, 45, 141, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 },
                    { 20, "BORS Holding", new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Upload projektu na github a předání", new DateTime(2024, 2, 23, 20, 10, 52, 427, DateTimeKind.Unspecified), "Josef Dvořák", 1, new DateTime(2024, 2, 24, 20, 6, 27, 11, DateTimeKind.Unspecified), "Pavel Stříž", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "TaskChecklist",
                columns: new[] { "Id", "Deadline", "Description", "DoneAt", "Priority", "Status", "StepName", "TaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 26, 23, 59, 59, 0, DateTimeKind.Unspecified), "Workflow: Code-First\nTyp databáze: Microsoft SQL Server (SSMS 2018)", new DateTime(2024, 2, 23, 20, 12, 40, 418, DateTimeKind.Unspecified), 1, 1, "Vytvoření databáze", 1 },
                    { 2, new DateTime(2024, 2, 27, 23, 59, 59, 0, DateTimeKind.Unspecified), "Technologie: FluentAPI\nJazyk C#", new DateTime(2024, 2, 23, 20, 12, 40, 418, DateTimeKind.Unspecified), 1, 1, "Vytvoření datového modelu", 1 },
                    { 3, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Framework: Blazor", new DateTime(2024, 2, 23, 20, 12, 40, 418, DateTimeKind.Unspecified), 1, 1, "Návrh oken", 1 },
                    { 4, new DateTime(2024, 3, 1, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 12, 40, 418, DateTimeKind.Unspecified), 1, 1, "Odladění bugů", 1 },
                    { 5, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Aby se v databázi ukládal i čas", null, 2, 2, "Upravení formátu", 4 },
                    { 6, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Description => Name", null, 3, 2, "Tabulka: Tasks", 5 },
                    { 7, new DateTime(2024, 2, 26, 23, 59, 59, 0, DateTimeKind.Unspecified), "Tak aby mohl obsahovat null hodnoty (nullable)", new DateTime(2024, 2, 23, 20, 8, 16, 719, DateTimeKind.Unspecified), 1, 1, "Sloupec: Description", 6 },
                    { 8, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), 1, 1, "Seznam všech úkolů", 7 },
                    { 9, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), 1, 1, "Seznam úkolů konkrétního zadavatele", 7 },
                    { 10, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), 1, 1, "Seznam úkolů konkrétního řešitele", 7 },
                    { 11, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), 1, 1, "Nevyřešené úkoly", 7 },
                    { 12, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 8, 33, 381, DateTimeKind.Unspecified), 1, 1, "Nevyřešené úkoly, po termínu", 7 },
                    { 13, new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), "které obsahují nějaký bod z checklistu po termínu.", null, 1, 2, "Nevyřešené úkoly", 7 },
                    { 14, new DateTime(2024, 2, 27, 23, 59, 59, 0, DateTimeKind.Unspecified), "Vytvořit logiku pro zahození neuložených dat do Local/Session storage, tak aby se po refreshu stránky smazala", null, 1, 2, "Logika pro zahození dat", 8 },
                    { 15, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Z disabled => readonly", null, 3, 3, "Změna tagů", 9 },
                    { 16, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 9, 0, 380, DateTimeKind.Unspecified), 1, 1, "Čtení dokumentace", 10 },
                    { 17, new DateTime(2024, 2, 27, 23, 59, 59, 0, DateTimeKind.Unspecified), "Změna typu na webassembly z důvodu nefunkčnosti v původním Blazor Server App.\n*Spontánní naříkání*", new DateTime(2024, 2, 23, 20, 9, 0, 380, DateTimeKind.Unspecified), 1, 1, "Změna typu projektu", 10 },
                    { 18, new DateTime(2024, 2, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 9, 19, 487, DateTimeKind.Unspecified), 1, 1, "Controller", 11 },
                    { 19, new DateTime(2024, 2, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 9, 19, 487, DateTimeKind.Unspecified), 1, 1, "Service", 11 },
                    { 20, new DateTime(2024, 2, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 9, 19, 487, DateTimeKind.Unspecified), 1, 1, "Interface", 11 },
                    { 21, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 9, 39, 884, DateTimeKind.Unspecified), 1, 1, "Hledání příčiny", 12 },
                    { 22, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Změna TaskModel task na nullable objekt", new DateTime(2024, 2, 23, 20, 9, 39, 884, DateTimeKind.Unspecified), 1, 1, "Změna datového typu", 12 },
                    { 23, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "Přidání attributu JsonIgnore", new DateTime(2024, 2, 23, 20, 9, 39, 884, DateTimeKind.Unspecified), 1, 1, "Přidání attributu", 12 },
                    { 24, new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 23, 20, 10, 2, 584, DateTimeKind.Unspecified), 1, 1, "Stránka detail", 14 },
                    { 25, new DateTime(2024, 2, 24, 23, 59, 59, 0, DateTimeKind.Unspecified), null, null, 1, 2, "WorkflowItem", 14 },
                    { 26, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "K jednotlivým konfiguracím přidat simulovaná data.", new DateTime(2024, 2, 23, 20, 10, 23, 605, DateTimeKind.Unspecified), 3, 1, "Postup", 15 },
                    { 27, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Ke každému úkolu přidat možnost přidání přílohy.", null, 3, 2, "Postup", 16 },
                    { 28, new DateTime(2024, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), "K jednotlivým částem kódu vytvořit unit testy pro zjištění funkčnosti.", null, 1, 2, "Zadání", 18 },
                    { 29, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Po vložení přeslimitního počtu znaků se nic nestane. Oprava: Přidán atribut pro validaci", new DateTime(2024, 2, 23, 23, 12, 30, 129, DateTimeKind.Unspecified), 1, 1, "Detail & Nový", 19 },
                    { 30, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "U položek Termín se po stisknutí na tlačítko Vymazat a Uložit nastaví datum na 01.01.0001 Oprava: Nastavena defaultní hodnota pro parametr Termín", new DateTime(2024, 2, 23, 23, 12, 30, 129, DateTimeKind.Unspecified), 1, 1, "Detail & Nový", 19 },
                    { 31, new DateTime(2024, 2, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Textové pole je moc krátké pro delší zprávu", null, 1, 1, "Chat", 19 }
                });

            migrationBuilder.InsertData(
                table: "TaskMessages",
                columns: new[] { "Id", "Message", "PublishedAt", "TaskId", "UserName" },
                values: new object[,]
                {
                    { 1, "Toto je testovací zpráva", new DateTime(2024, 2, 24, 0, 28, 48, 935, DateTimeKind.Unspecified), 1, "Pavel Stříž" },
                    { 2, "", new DateTime(2024, 2, 24, 0, 28, 56, 530, DateTimeKind.Unspecified), 1, "Honza Novák" },
                    { 3, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 30, 7, 930, DateTimeKind.Unspecified), 4, "Josef Dvořák" },
                    { 4, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 30, 14, 253, DateTimeKind.Unspecified), 4, "Honza Novák" },
                    { 5, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 30, 46, 358, DateTimeKind.Unspecified), 7, "Pavel Stříž" },
                    { 6, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 30, 54, 753, DateTimeKind.Unspecified), 7, "Honza Novák" },
                    { 7, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 31, 6, 905, DateTimeKind.Unspecified), 17, "Josef Dvořák" },
                    { 8, "Toto je testovací zpráva.", new DateTime(2024, 2, 24, 0, 31, 18, 869, DateTimeKind.Unspecified), 17, "Pavel Stříž" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_TaskId",
                table: "TaskAttachments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskChecklist_TaskId",
                table: "TaskChecklist",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMessages_TaskId",
                table: "TaskMessages",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "TaskAttachments");

            migrationBuilder.DropTable(
                name: "TaskChecklist");

            migrationBuilder.DropTable(
                name: "TaskMessages");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
