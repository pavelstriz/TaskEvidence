using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskEvidence.Helpers;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Models
{
    public class TaskModel : TaskBase
    {
        public TaskModel()
        {
            Checklist = new HashSet<ChecklistModel>();
            Messages = new HashSet<MessageModel>();
            Attachments = new HashSet<AttachmentModel>();
        }
        public int Id { get; set; }
        public ICollection<ChecklistModel>? Checklist { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
        public ICollection<AttachmentModel>? Attachments { get; set; }
        public string Company { get; set; }

        [Required(ErrorMessage = "Toto pole je povinné.")]
        [MaxLength(100, ErrorMessage = "Maximální délka je 100 znaků.")]
        public string Description { get; set; }

        public string Orderer { get; set; }

        [Required(ErrorMessage = "Toto pole je povinné.")]
        [MaxLength(50, ErrorMessage = "Maximální délka je 50 znaků.")]
        public string Solver { get; set; }
        public int State { get; set; } //1 active, 2 - deleted
        [JsonIgnore]
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
