using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEvidence.Helpers;
using TaskEvidence.Models;

namespace TaskEvidence.EntityConfigurations
{
    public class ChecklistConfiguration : IEntityTypeConfiguration<ChecklistModel>
    {
        public void Configure(EntityTypeBuilder<ChecklistModel> builder)
        {
            // Table name
            builder.ToTable("TaskChecklist");

            // Primary key
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Property configurations
            builder.Property(c => c.StepName)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(c => c.Priority)
                .IsRequired();

            builder.Property(c => c.Deadline)
                .IsRequired();

            builder.Property(c => c.Status)
                .IsRequired();

            builder.Property(c => c.DoneAt);

            builder.Ignore(c => c.PublishedAt);

            /*builder.HasOne(c => c.Task)
                .WithMany(t => t.Checklists)
                .HasForeignKey(c => c.Task.Id)
                .IsRequired();*/ // Adjust as needed

            builder.HasData(
            new ChecklistModel
            {
                Id = 1,
                StepName = "Vytvoření databáze",
                Description = "Workflow: Code-First\nTyp databáze: Microsoft SQL Server (SSMS 2018)",
                TaskId = 1,
                Deadline = new DateTime(2024, 2, 26, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 12, 40, 418),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 2,
                StepName = "Vytvoření datového modelu",
                Description = "Technologie: FluentAPI\nJazyk C#",
                TaskId = 1,
                Deadline = new DateTime(2024, 2, 27, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 12, 40, 418),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 3,
                StepName = "Návrh oken",
                Description = "Framework: Blazor",
                TaskId = 1,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 12, 40, 418),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 4,
                StepName = "Odladění bugů",
                Description = null,
                TaskId = 1,
                Deadline = new DateTime(2024, 3, 1, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 12, 40, 418),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 5,
                StepName = "Upravení formátu",
                Description = "Aby se v databázi ukládal i čas",
                TaskId = 4,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.Medium
            },
            new ChecklistModel
            {
                Id = 6,
                StepName = "Tabulka: Tasks",
                Description = "Description => Name",
                TaskId = 5,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.Low
            },
            new ChecklistModel
            {
                Id = 7,
                StepName = "Sloupec: Description",
                Description = "Tak aby mohl obsahovat null hodnoty (nullable)",
                TaskId = 6,
                Deadline = new DateTime(2024, 2, 26, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 16, 719),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 8,
                StepName = "Seznam všech úkolů",
                Description = null,
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 9,
                StepName = "Seznam úkolů konkrétního zadavatele",
                Description = null,
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 10,
                StepName = "Seznam úkolů konkrétního řešitele",
                Description = null,
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 11,
                StepName = "Nevyřešené úkoly",
                Description = null,
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 12,
                StepName = "Nevyřešené úkoly, po termínu",
                Description = null,
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 13,
                StepName = "Nevyřešené úkoly",
                Description = "které obsahují nějaký bod z checklistu po termínu.",
                TaskId = 7,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 14,
                StepName = "Logika pro zahození dat",
                Description = "Vytvořit logiku pro zahození neuložených dat do Local/Session storage, tak aby se po refreshu stránky smazala",
                TaskId = 8,
                Deadline = new DateTime(2024, 2, 27, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 15,
                StepName = "Změna tagů",
                Description = "Z disabled => readonly",
                TaskId = 9,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = null,
                Status = Status.Abandoned,
                Priority = Priority.Low
            },
            new ChecklistModel
            {
                Id = 16,
                StepName = "Čtení dokumentace",
                Description = null,
                TaskId = 10,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 0, 380),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 17,
                StepName = "Změna typu projektu",
                Description = "Změna typu na webassembly z důvodu nefunkčnosti v původním Blazor Server App.\n*Spontánní naříkání*",
                TaskId = 10,
                Deadline = new DateTime(2024, 2, 27, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 0, 380),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 18,
                StepName = "Controller",
                Description = null,
                TaskId = 11,
                Deadline = new DateTime(2024, 2, 29, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 19, 487),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 19,
                StepName = "Service",
                Description = null,
                TaskId = 11,
                Deadline = new DateTime(2024, 2, 29, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 19, 487),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 20,
                StepName = "Interface",
                Description = null,
                TaskId = 11,
                Deadline = new DateTime(2024, 2, 29, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 19, 487),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 21,
                StepName = "Hledání příčiny",
                Description = null,
                TaskId = 12,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 39, 884),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 22,
                StepName = "Změna datového typu",
                Description = "Změna TaskModel task na nullable objekt",
                TaskId = 12,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 39, 884),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 23,
                StepName = "Přidání attributu",
                Description = "Přidání attributu JsonIgnore",
                TaskId = 12,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 39, 884),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 24,
                StepName = "Stránka detail",
                Description = null,
                TaskId = 14,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 10, 2, 584),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 25,
                StepName = "WorkflowItem",
                Description = null,
                TaskId = 14,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 26,
                StepName = "Postup",
                Description = "K jednotlivým konfiguracím přidat simulovaná data.",
                TaskId = 15,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 20, 10, 23, 605),
                Status = Status.Done,
                Priority = Priority.Low
            },
            new ChecklistModel
            {
                Id = 27,
                StepName = "Postup",
                Description = "Ke každému úkolu přidat možnost přidání přílohy.",
                TaskId = 16,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.Low
            },
            new ChecklistModel
            {
                Id = 28,
                StepName = "Zadání",
                Description = "K jednotlivým částem kódu vytvořit unit testy pro zjištění funkčnosti.",
                TaskId = 18,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 29,
                StepName = "Detail & Nový",
                Description = "Po vložení přeslimitního počtu znaků se nic nestane. Oprava: Přidán atribut pro validaci",
                TaskId = 19,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 23, 12, 30, 129),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 30,
                StepName = "Detail & Nový",
                Description = "U položek Termín se po stisknutí na tlačítko Vymazat a Uložit nastaví datum na 01.01.0001 Oprava: Nastavena defaultní hodnota pro parametr Termín",
                TaskId = 19,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                DoneAt = new DateTime(2024, 2, 23, 23, 12, 30, 129),
                Status = Status.Done,
                Priority = Priority.High
            },
            new ChecklistModel
            {
                Id = 31,
                StepName = "Chat",
                Description = "Textové pole je moc krátké pro delší zprávu",
                TaskId = 19,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                Status = Status.Done,
                Priority = Priority.High
            }
            );
        }
    }
}
