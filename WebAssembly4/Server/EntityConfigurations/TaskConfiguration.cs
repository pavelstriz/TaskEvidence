using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskEvidence.Helpers;
using TaskEvidence.Models;

namespace TaskEvidence.EntityConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Company)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(c => c.Orderer)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(c => c.Solver)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(c => c.Priority)
            .IsRequired();

            builder.Property(c => c.Deadline)
            .IsRequired(false);

            builder.Property(c => c.PublishedAt)
            .IsRequired(false);

            builder.Property(c => c.DoneAt)
            .IsRequired(false);

            builder.Property(c => c.Status)
            .IsRequired();
            
            builder.Property(c => c.State)
            .IsRequired();

            //Relations
            builder.HasMany(c => c.Checklist)
           .WithOne(cl => cl.Task)
           .HasForeignKey(cl => cl.TaskId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Messages)
           .WithOne(cl => cl.Task)
           .HasForeignKey(cl => cl.TaskId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Attachments)
           .WithOne(cl => cl.Task)
           .HasForeignKey(cl => cl.TaskId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            new TaskModel
            {
                Id = 1,
                Company = "BORS Holding",
                Description = "Vytvoření systému pro evidenci úkolů",
                Orderer = "Honza Novák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 3, 1, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 27, 24, 609),
                DoneAt = new DateTime(2024, 2, 23, 20, 12, 40, 418),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 2,
                Company = "BORS Holding",
                Description = "Přidání javascriptu pro zvýraznění selectu v tabulce",
                Orderer = "Josef Dvořák",
                Solver = "Honza Novák",
                State = 1,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 28, 13, 861),
                DoneAt = new DateTime(2024, 2, 23, 20, 7, 30, 807),
                Status = Status.Done,
                Priority = Priority.Low
            },
            new TaskModel
            {
                Id = 3,
                Company = "BORS Holding",
                Description = "Přidání css stylu pro grid",
                Orderer = "Pavel Stříž",
                Solver = "Honza Novák",
                State = 1,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 29, 7, 762),
                DoneAt = new DateTime(2024, 2, 23, 20, 7, 35, 831),
                Status = Status.Done,
                Priority = Priority.Low
            },
            new TaskModel
            {
                Id = 4,
                Company = "BORS Service",
                Description = "Upravení logiky pro zápis Deadline",
                Orderer = "Pavel Stříž",
                Solver = "Josef Dvořák",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 32, 13, 919),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.Medium
            },
            new TaskModel
            {
                Id = 5,
                Company = "BORS Holding",
                Description = "Přejmenování sloupce v databázi",
                Orderer = "Josef Dvořák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 33, 24, 150),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 6,
                Company = "BORS Logistics",
                Description = "Upravení datového typu sloupce v databázi.",
                Orderer = "Pavel Stříž",
                Solver = "Josef Dvořák",
                State = 1,
                Deadline = new DateTime(2024, 2, 26, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 35, 28, 9),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 16, 719),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 7,
                Company = "BORS Holding",
                Description = "Vytvoření pohledů",
                Orderer = "Honza Novák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 38, 48, 432),
                DoneAt = new DateTime(2024, 2, 23, 20, 8, 33, 381),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 8,
                Company = "BORS Holding",
                Description = "Discard Feature",
                Orderer = "Pavel Stříž",
                Solver = "Honza Novák",
                State = 1,
                Deadline = new DateTime(2024, 2, 27, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 42, 10, 842),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 9,
                Company = "BORS Holding",
                Description = "Změna tagů",
                Orderer = "Josef Dvořák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 43, 27, 900),
                DoneAt = null,
                Status = Status.Abandoned,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 10,
                Company = "BORS Holding",
                Description = "Implementace komunikace formou chatu",
                Orderer = "Honza Novák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 51, 8, 242),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 0, 380),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 11,
                Company = "BORS Service",
                Description = "Rozdělení kódu",
                Orderer = "Honza Novák",
                Solver = "Josef Dvořák",
                State = 1,
                Deadline = new DateTime(2024, 2, 29, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 53, 10, 937),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 19, 487),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 12,
                Company = "BORS Holding",
                Description = "Oprava chyb při komunikaci client-server",
                Orderer = "Josef Dvořák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 56, 1, 268),
                DoneAt = new DateTime(2024, 2, 23, 20, 9, 39, 884),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 13,
                Company = "BORS Logistics",
                Description = "Přidání validací polí na frontendu",
                Orderer = "Josef Dvořák",
                Solver = "Honza Novák",
                State = 2,
                Deadline = new DateTime(2024, 2, 27, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 57, 1, 64),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 14,
                Company = "BORS Logistics",
                Description = "Přidání validací polí na frontendu",
                Orderer = "Pavel Stříž",
                Solver = "Honza Novák",
                State = 1,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 19, 58, 4, 53),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 15,
                Company = "BORS Holding",
                Description = "Přidat script pro simulaci dat",
                Orderer = "Honza Novák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 20, 0, 13, 893),
                DoneAt = new DateTime(2024, 2, 23, 20, 10, 23, 605),
                Status = Status.Done,
                Priority = Priority.Low
            },
            new TaskModel
            {
                Id = 16,
                Company = "BORS Holding",
                Description = "Možnost přidání přílohy",
                Orderer = "Pavel Stříž",
                Solver = "Honza Novák",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 20, 1, 58, 293),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.Low
            },
            new TaskModel
            {
                Id = 17,
                Company = "BORS Holding",
                Description = "Refaktoring jednotlivých částí kódu.",
                Orderer = "Honza Novák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 24, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 20, 2, 40, 263),
                DoneAt = new DateTime(2024, 2, 23, 20, 10, 39, 579),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 18,
                Company = "BORS Holding",
                Description = "Vytvoření unit testů",
                Orderer = "Pavel Stříž",
                Solver = "Josef Dvořák",
                State = 1,
                Deadline = new DateTime(2024, 2, 28, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 20, 5, 52, 375),
                DoneAt = null,
                Status = Status.Waiting,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 19,
                Company = "BORS Holding",
                Description = "Regresní testy",
                Orderer = "Pavel",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 23, 23, 10, 45, 141),
                Status = Status.Done,
                Priority = Priority.High
            },
            new TaskModel
            {
                Id = 20,
                Company = "BORS Holding",
                Description = "Upload projektu na github a předání",
                Orderer = "Josef Dvořák",
                Solver = "Pavel Stříž",
                State = 1,
                Deadline = new DateTime(2024, 2, 25, 23, 59, 59),
                PublishedAt = new DateTime(2024, 2, 24, 20, 6, 27, 11),
                DoneAt = new DateTime(2024, 2, 23, 20, 10, 52, 427),
                Status = Status.Done,
                Priority = Priority.High
            }
            );
        }
    }
}
