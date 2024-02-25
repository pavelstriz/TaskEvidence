using Microsoft.EntityFrameworkCore;
using TaskEvidence.EntityConfigurations;
using TaskEvidence.Models;
using TaskEvidence.Server.EntityConfigurations;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Data
{
    public class EvidenceDbContext : DbContext
    {
        public EvidenceDbContext(DbContextOptions<EvidenceDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new ChecklistConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ChecklistModel> TaskChecklist { get; set; }
        public DbSet<MessageModel> TaskMessages { get; set; }
        public DbSet<AttachmentModel> TaskAttachments { get; set; }

    }
}
