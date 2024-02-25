using Microsoft.AspNetCore.Mvc;
using TaskEvidence.Models;
using TaskEvidence.Shared.Models;

namespace TaskEvidence.Services
{
    public interface ITaskService
    {
        Task<TaskModel> GetTaskByIdAsync(int id);
        Task<List<TaskModel>> GetTasksAsync();
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(int id, TaskModel updatedTask);
        Task<TaskModel> RemoveTask(int id, TaskModel updatedTask);
        Task<List<TaskModel>> RemoveTasks(List<TaskModel> updatedTasks);
        Task<TaskModel> UpdateTaskAttachments(int id, List<AttachmentModel> updatedAttachments);
        //Task<byte[]> DownloadTaskAttachmentsAsync(int taskId);
    }
}
