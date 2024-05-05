using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    /// <summary>
    /// Classe que implementa o repositório de tarefas.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        /// <summary>
        /// Construtor da classe TaskRepository.
        /// </summary>
        /// <param name="taskSystemDBContext">Contexto do banco de dados da aplicação.</param>
        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        /// <inheritdoc/>
        public async Task<TaskModel> GetById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        /// <inheritdoc/>
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Task for the Id:{id} was not found in the database.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        /// <inheritdoc/>
        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Task for the Id:{id} was not found in the database.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
