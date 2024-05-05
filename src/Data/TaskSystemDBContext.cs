using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.Map;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    /// <summary>
    /// Classe responsável por representar o contexto do banco de dados da aplicação.
    /// </summary>
    public class TaskSystemDBContext : DbContext
    {
        /// <summary>
        /// Construtor da classe TaskSystemDBContext.
        /// </summary>
        /// <param name="options">Opções de configuração do contexto do banco de dados.</param>
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options) : base(options)
        {
        }
         
        /// <summary>
        /// Define a tabela de usuários no banco de dados.
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Define a tabela de tarefas no banco de dados.
        /// </summary>
        public DbSet<TaskModel> Tasks { get; set; }

        /// <summary>
        /// Sobrescreve o método OnModelCreating para configurar o modelo do banco de dados.
        /// </summary>
        /// <param name="modelBuilder">Construtor de modelos utilizado para configurar o modelo do banco de dados.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações de mapeamento das entidades User e Task.
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
