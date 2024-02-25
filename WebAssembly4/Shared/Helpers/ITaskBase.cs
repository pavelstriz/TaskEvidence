namespace TaskEvidence.Helpers
{
    public interface ITaskBase
    {
        public DateTime? Deadline { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? DoneAt { get; set; }
        public Status Status { get; set; }
    }
}
