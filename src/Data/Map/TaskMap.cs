using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    /// <summary>
    /// Classe responsável por mapear a entidade TaskModel para o banco de dados.
    /// </summary>
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        /// <summary>
        /// Configura o mapeamento da entidade TaskModel.
        /// </summary>
        /// <param name="builder">Instância de EntityTypeBuilder para configuração.</param>
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            // Define a chave primária da entidade como o campo Id.
            builder.HasKey(x => x.Id);
            
            // Configura a propriedade Name como obrigatória e com no máximo 255 caracteres.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            
            // Configura a propriedade Description com no máximo 1000 caracteres.
            builder.Property(x => x.Description).HasMaxLength(1000);
            
            // Configura a propriedade Status como obrigatória.
            builder.Property(x => x.Status).IsRequired();
            
            // Configura a propriedade UserId.
            builder.Property(x => x.UserId);
            
            // Define o relacionamento de muitos para um com a entidade User.
            builder.HasOne(x => x.User);
        }
    }
}
