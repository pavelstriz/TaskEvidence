using TaskEvidence.Controllers;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Services
{
    public interface IChatService
    {
        Task<List<MessageModel>> GetMessagesByIdAsync(int id);
        Task AddTask(MessageModel message);
    }
}