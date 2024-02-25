using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskEvidence.Controllers;
using TaskEvidence.Data;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Services
{
    public class ChatService : IChatService
    {
        private readonly EvidenceDbContext _context;

        public ChatService(EvidenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<MessageModel>> GetMessagesByIdAsync(int id)
        {
            return await _context.TaskMessages
                .Where(t => t.TaskId == id)
                .OrderBy(d => d.PublishedAt)
                .ToListAsync();
        }

        public async Task AddTask(MessageModel message)
        {
            _context.TaskMessages.Add(message);
            await _context.SaveChangesAsync();

        }
    }
}
