using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskEvidence.Helpers;
using TaskEvidence.Models;

namespace TaskEvidence.Shared.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public int TaskId { get; set; }
        public DateTime? PublishedAt { get; set; }

        [JsonIgnore] //Render error
        public TaskModel? Task { get; set; } //? nullable error

        [JsonIgnore]
        [NotMapped]
        public bool CurrentUser { get; set; }

    }
}
