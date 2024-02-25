using Microsoft.AspNetCore.Mvc;
using TaskEvidence.Models;
using TaskEvidence.Services;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getTask/{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskByIdAsync(int id)
        {
            try
            {
                var result = await _taskService.GetTaskByIdAsync(id);
                return result != null
                    ? Ok(result)
                    : NotFound($"Task with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the task: {ex.Message}");
            }
        }

        [HttpGet("getTasks")]
        public async Task<ActionResult<List<TaskModel>>> GetTasksAsync()
        {
            try
            {
                var result = await _taskService.GetTasksAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching tasks: {ex.Message}");
            }
        }

        [HttpPost("createTask")]
        public async Task<IActionResult> AddTask(TaskModel task)
        {
            try
            {
                var result = await _taskService.AddTask(task);
                return result != null
                    ? Ok(result)
                    : BadRequest("Failed to create task. Please check your input data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the task: {ex.Message}");
            }
        }

        [HttpPatch("updateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel updatedTask)
        {
            try
            {
                var result = await _taskService.UpdateTask(id, updatedTask);
                return result != null
                    ? Ok(result)
                    : NotFound($"Task with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the task: {ex.Message}");
            }
        }

        [HttpPatch("sendToArchive/{id}")]
        public async Task<IActionResult> RemoveTask(int id, TaskModel updatedTask)
        {
            try
            {
                var result = await _taskService.RemoveTask(id, updatedTask);
                return result != null
                    ? Ok(result)
                    : NotFound($"Task with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing the task: {ex.Message}");
            }
        }

        [HttpPatch("sendToArchiveMany")]
        public async Task<ActionResult<List<TaskModel>>> RemoveTasks(List<TaskModel> updatedTasks)
        {
            try
            {
                var result = await _taskService.RemoveTasks(updatedTasks);
                return result != null
                    ? Ok(result)
                    : NotFound($"An unexpected error has occured.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing tasks: {ex.Message}");
            }
        }
        [HttpPut("updateAttachments/{id}")]
        public async Task<IActionResult> UpdateTaskAttachments(int id, List<AttachmentModel> updatedAttachments)
        {
            try
            {
                var updatedTask = await _taskService.UpdateTaskAttachments(id, updatedAttachments);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
