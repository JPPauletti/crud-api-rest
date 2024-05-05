using TaskSystem.Enums;

namespace TaskSystem.Models
{
    /// <summary>
    /// Classe que representa uma tarefa.
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Obtém ou define o ID da tarefa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome da tarefa.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Obtém ou define a descrição da tarefa.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Obtém ou define o status da tarefa.
        /// </summary>
        public Task_Status Status { get; set; }

        /// <summary>
        /// Obtém ou define o ID do usuário associado à tarefa.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Obtém ou define o usuário associado à tarefa.
        /// </summary>
        public virtual UserModel? User { get; set; }
    }
}
