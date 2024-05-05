using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de todos os usuários.</returns>
        Task<List<UserModel>> GetAllUsers();

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário desejado.</param>
        /// <returns>Usuário correspondente ao ID fornecido.</returns>
        Task<UserModel> GetById(int id);

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        /// <param name="user">Objeto contendo os dados do usuário a ser adicionado.</param>
        /// <returns>Usuário adicionado.</returns>
        Task<UserModel> Add(UserModel user);

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="user">Objeto contendo os novos dados do usuário.</param>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <returns>Usuário atualizado.</returns>
        Task<UserModel> Update(UserModel user, int id);

        /// <summary>
        /// Exclui um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Indicação se a exclusão foi bem-sucedida.</returns>
        Task<bool> Delete(int id);
    }
}
