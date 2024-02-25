using Microsoft.EntityFrameworkCore;
using TaskEvidence.Data;
using TaskEvidence.Models;

namespace TaskEvidence.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly EvidenceDbContext _context;

        public ChecklistService(EvidenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChecklistModel>> GetChecklistByTaskAsync(int taskId)
        {
            return await _context.TaskChecklist
                .Where(t => t.TaskId == taskId)
                .OrderBy(t => t.Id)
                .ToListAsync();
        }
    }
}
