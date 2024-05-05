using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    /// <summary>
    /// Classe responsável por mapear a entidade UserModel para o banco de dados.
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        /// <summary>
        /// Configura o mapeamento da entidade UserModel.
        /// </summary>
        /// <param name="builder">Instância de EntityTypeBuilder para configuração.</param>
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            // Define a chave primária da entidade como o campo Id.
            builder.HasKey(x => x.Id);
            
            // Configura a propriedade Name como obrigatória e com no máximo 255 caracteres.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            
            // Configura a propriedade Email como obrigatória e com no máximo 150 caracteres.
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
