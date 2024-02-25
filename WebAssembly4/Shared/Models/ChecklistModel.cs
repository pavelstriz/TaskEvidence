using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskEvidence.Helpers;

namespace TaskEvidence.Models
{
    public class ChecklistModel : TaskBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public string StepName { get; set; }
        public string? Description { get; set; }
        // Foreign key
        public int TaskId { get; set; }
        [JsonIgnore] //Render error
        public TaskModel? Task { get; set; } //? nullable error

        [NotMapped] //EF error
        public int Index { get; set; }
        [NotMapped]
        public bool ShowDescription { get; set; }


    }
}
