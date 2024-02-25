using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Server.EntityConfigurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<AttachmentModel>
    {
        public void Configure(EntityTypeBuilder<AttachmentModel> builder)
        {
            builder.ToTable("TaskAttachments");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.FileName)
                .IsRequired();

            builder.Property(c => c.Data)
                .IsRequired();

            builder.Property(c => c.State)
            .IsRequired();

        }
    }
}
