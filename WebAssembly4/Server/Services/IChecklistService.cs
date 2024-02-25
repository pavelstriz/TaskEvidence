using TaskEvidence.Models;

namespace TaskEvidence.Services
{
    public interface IChecklistService
    {
        Task<List<ChecklistModel>> GetChecklistByTaskAsync(int taskId);
    }
}