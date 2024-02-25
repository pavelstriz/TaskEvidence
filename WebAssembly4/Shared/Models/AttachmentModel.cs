using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskEvidence.Models;

namespace TaskEvidence.Shared.Models
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public int TaskId { get; set; }
        [JsonIgnore] //Render error
        public TaskModel? Task { get; set; } //? nullable error
        public int State { get; set; } //1 active, 2 - deleted
    }
}
