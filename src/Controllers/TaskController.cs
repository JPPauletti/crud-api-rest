using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a tarefas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// Construtor da classe TaskController.
        /// </summary>
        /// <param name="taskRepository">Instância da interface ITaskRepository.</param>
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Obtém todas as tarefas cadastradas.
        /// </summary>
        /// <returns>Lista de todas as tarefas.</returns>
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ListAll()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        /// <summary>
        /// Obtém uma tarefa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa desejada.</param>
        /// <returns>Tarefa correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetById(int id)
        {
            TaskModel task = await _taskRepository.GetById(id);
            return Ok(task);
        }

        /// <summary>
        /// Registra uma nova tarefa.
        /// </summary>
        /// <param name="taskModel">Objeto contendo os dados da tarefa a ser registrada.</param>
        /// <returns>Tarefa registrada.</returns>
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.Add(taskModel);
            return Ok(task);
        }

        /// <summary>
        /// Atualiza os dados de uma tarefa existente.
        /// </summary>
        /// <param name="taskModel">Objeto contendo os novos dados da tarefa.</param>
        /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <returns>Tarefa atualizada.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.Update(taskModel, id);
            return Ok(task);
        }

        /// <summary>
        /// Exclui uma tarefa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da tarefa a ser excluída.</param>
        /// <returns>Indicação se a exclusão foi bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _taskRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
