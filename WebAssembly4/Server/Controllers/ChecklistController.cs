using Microsoft.AspNetCore.Mvc;
using TaskEvidence.Models;
using TaskEvidence.Services;

namespace TaskEvidence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }
        [HttpGet("getChecklist/{taskId}")]
        public async Task<List<ChecklistModel>> GetChecklistByTaskAsync(int taskId)
        {
            return await _checklistService.GetChecklistByTaskAsync(taskId);
        }
    }
}
