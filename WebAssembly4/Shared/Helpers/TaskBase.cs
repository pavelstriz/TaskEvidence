

namespace TaskEvidence.Helpers
{
    public enum Priority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }
    public enum Status
    {
        Done = 1,
        Waiting = 2,
        Abandoned = 3
    }
    public abstract class TaskBase : ITaskBase
    {
        public DateTime? Deadline { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? DoneAt { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}
