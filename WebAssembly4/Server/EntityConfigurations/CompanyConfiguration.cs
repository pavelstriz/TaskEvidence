using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEvidence.Models;

namespace TaskEvidence.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasData(
                new CompanyModel { Id = 1, Name = "BORS Holding", Description = "desc1", State = 1},
                new CompanyModel { Id = 2, Name = "BORS Service", Description = "desc2", State = 1},
                new CompanyModel { Id = 3, Name = "BORS Logistics", Description = "desc3", State = 1}
                );
        }
    }
}
