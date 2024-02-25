using Microsoft.AspNetCore.Mvc;
using TaskEvidence.Services;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("getChatThread/{id}")]
        public async Task<List<MessageModel>> GetMessagesByIdAsync(int id)
        {
            return await _chatService.GetMessagesByIdAsync(id);
        }

        [HttpPost("postMessage")]
        public async Task AddTask(MessageModel message)
        {
            await _chatService.AddTask(message);
        }
    }
}
