using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEvidence.Models;
using TaskEvidence.Shared.Models;
namespace TaskEvidence.Server.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            // Table name
            builder.ToTable("TaskMessages");

            // Primary key
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Property configurations
            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(c => c.UserName)
                .IsRequired();

            builder.Property(c => c.PublishedAt)
                .IsRequired();

            // Exclude the inherited property from mapping
            //builder.Ignore(c => c.DoneAt);
            //builder.Ignore(c => c.Status);
            //builder.Ignore(c => c.Priority);
            //builder.Ignore(c => c.Deadline);

            builder.HasData(
            new MessageModel
            {
                Id = 1,
                Message = "Toto je testovací zpráva",
                UserName = "Pavel Stříž",
                TaskId = 1,
                PublishedAt = new DateTime(2024, 02, 24, 00, 28, 48, 935)
            },
            new MessageModel
            {
                Id = 2,
                Message = "",
                UserName = "Honza Novák",
                TaskId = 1,
                PublishedAt = new DateTime(2024, 02, 24, 00, 28, 56, 530)
            },
            new MessageModel
            {
                Id = 3,
                Message = "Toto je testovací zpráva.",
                UserName = "Josef Dvořák",
                TaskId = 4,
                PublishedAt = new DateTime(2024, 02, 24, 00, 30, 07, 930)
            },
            new MessageModel
            {
                Id = 4,
                Message = "Toto je testovací zpráva.",
                UserName = "Honza Novák",
                TaskId = 4,
                PublishedAt = new DateTime(2024, 02, 24, 00, 30, 14, 253)
            },
            new MessageModel
            {
                Id = 5,
                Message = "Toto je testovací zpráva.",
                UserName = "Pavel Stříž",
                TaskId = 7,
                PublishedAt = new DateTime(2024, 02, 24, 00, 30, 46, 358)
            },
            new MessageModel
            {
                Id = 6,
                Message = "Toto je testovací zpráva.",
                UserName = "Honza Novák",
                TaskId = 7,
                PublishedAt = new DateTime(2024, 02, 24, 00, 30, 54, 753)
            },
            new MessageModel
            {
                Id = 7,
                Message = "Toto je testovací zpráva.",
                UserName = "Josef Dvořák",
                TaskId = 17,
                PublishedAt = new DateTime(2024, 02, 24, 00, 31, 06, 905)
            },
            new MessageModel
            {
                Id = 8,
                Message = "Toto je testovací zpráva.",
                UserName = "Pavel Stříž",
                TaskId = 17,
                PublishedAt = new DateTime(2024, 02, 24, 00, 31, 18, 869)
            }
            );
        }
    }
}
