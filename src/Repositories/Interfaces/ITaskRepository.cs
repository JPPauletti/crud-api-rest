using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    /// <summary>
    /// Interface para o repositório de tarefas.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Obtém todas as tarefas cadastradas.
        /// </summary>
        /// <returns>Lista de todas as tarefas.</returns>
        Task<List<TaskModel>> GetAllTasks();

        /// <summary>
        /// Obtém uma tarefa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa desejada.</param>
        /// <returns>Tarefa correspondente ao ID fornecido.</returns>
        Task<TaskModel> GetById(int id);

        /// <summary>
        /// Adiciona uma nova tarefa.
        /// </summary>
        /// <param name="task">Objeto contendo os dados da tarefa a ser adicionada.</param>
        /// <returns>Tarefa adicionada.</returns>
        Task<TaskModel> Add(TaskModel task);

        /// <summary>
        /// Atualiza os dados de uma tarefa existente.
        /// </summary>
        /// <param name="task">Objeto contendo os novos dados da tarefa.</param>
        /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <returns>Tarefa atualizada.</returns>
        Task<TaskModel> Update(TaskModel task, int id);

        /// <summary>
        /// Exclui uma tarefa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa a ser excluída.</param>
        /// <returns>Indicação se a exclusão foi bem-sucedida.</returns>
        Task<bool> Delete(int id);
    }
}
