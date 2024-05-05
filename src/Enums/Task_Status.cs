using System.ComponentModel;

namespace TaskSystem.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes estados de uma tarefa.
    /// </summary>
    public enum Task_Status
    {
        /// <summary>
        /// Tarefa a ser feita.
        /// </summary>
        [Description("To do")]
        ToDo = 1,

        /// <summary>
        /// Tarefa em andamento.
        /// </summary>
        [Description("In Progress")]
        InProgress = 2,

        /// <summary>
        /// Tarefa concluída.
        /// </summary>
        [Description("Completed")]
        Completed = 3
    }
}
