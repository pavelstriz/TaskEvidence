using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskEvidence.Data;
using TaskEvidence.Models;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Services
{
    public class TaskService : ITaskService
    {
        private readonly EvidenceDbContext _context;

        public TaskService(EvidenceDbContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
             var task = await _context.Tasks
                .Include(task => task.Checklist)
                .Include(task => task.Messages)
                .Include(task => task.Attachments.Where(attachment => attachment.State != 2))
                .FirstOrDefaultAsync(t => t.Id == id && t.State != 2);
            return task 
                ?? throw new InvalidOperationException($"Task with ID {id} not found.");
        }

        public async Task<List<TaskModel>> GetTasksAsync()
        {
            return await _context.Tasks
                .Include(task => task.Checklist)
                .Include(t => t.Messages)
                .Include(t => t.Attachments.Where(attachment => attachment.State != 2))
                .Where(s => s.State != 2)
                .ToListAsync();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
            //return new OkObjectResult("Task created successfully.");
        }

        public async Task<TaskModel> UpdateTask(int id, TaskModel updatedTask)
        {
            var existingTask = await _context.Tasks
                .Include(t => t.Checklist)
                .FirstOrDefaultAsync(t => t.Id == id && t.State != 2);

            if (existingTask == null)
                throw new InvalidOperationException($"Task with ID {id} not found.");

            existingTask.Checklist = updatedTask.Checklist;
            existingTask.Attachments = updatedTask.Attachments;
            existingTask.Company = updatedTask.Company;
            existingTask.Description = updatedTask.Description;
            existingTask.Orderer = updatedTask.Orderer;
            existingTask.Solver = updatedTask.Solver;
            existingTask.State = updatedTask.State;
            existingTask.Deadline = updatedTask.Deadline;
            existingTask.PublishedAt = updatedTask.PublishedAt;
            existingTask.DoneAt = updatedTask.DoneAt;
            existingTask.Status = updatedTask.Status;
            existingTask.Priority = updatedTask.Priority;
            await _context.SaveChangesAsync();
            return existingTask;

        }

        public async Task<TaskModel> RemoveTask(int id, TaskModel updatedTask)
        {
            var existingTask = await _context.Tasks
                .Include(t => t.Checklist)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTask == null)
                throw new InvalidOperationException($"Task with ID {id} not found.");

            existingTask.State = updatedTask.State;

            await _context.SaveChangesAsync();
            return existingTask;
            //return new OkObjectResult("Task has been successfully sent to archive.");
        }
        public async Task<TaskModel> UpdateTaskAttachments(int id, List<AttachmentModel> updatedAttachments)
        {
            var existingTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTask == null)
                throw new InvalidOperationException($"Task with ID {id} not found.");

            existingTask.Attachments = updatedAttachments;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<List<TaskModel>> RemoveTasks(List<TaskModel> updatedTasks)
        {
            var updatedTasksId = updatedTasks.Select(t => t.Id);

            var existingTasks = await _context.Tasks
                                             .Where(t => updatedTasksId.Contains(t.Id))
                                             .ToListAsync();
            existingTasks.Join(updatedTasks,
                       existingTask => existingTask.Id,
                       updatedTask => updatedTask.Id,
                       (existingTask, updatedTask) =>
                       {
                           existingTask.State = updatedTask.State;
                           return existingTask;
                       })
                 .ToList();

            await _context.SaveChangesAsync();
            return existingTasks;
            //return new OkObjectResult("Task has been successfully sent to archive.");
        }
        /*public async Task<byte[]> DownloadTaskAttachmentsAsync(int taskId)
        {
            try
            {
                var attachments = await _context.Tasks
                    .Where(a => a.TaskId == taskId)
                    .ToListAsync();

                if (attachments.Any())
                {
                    // For simplicity, return the first attachment
                    return attachments.FirstOrDefault()?.FileContent;
                }
                else
                {
                    throw new FileNotFoundException($"No attachments found for task ID: {taskId}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading task attachments: {ex.Message}", ex);
            }
        }*/
    }
}
