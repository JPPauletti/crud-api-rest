namespace TaskSystem.Models
{
    /// <summary>
    /// Classe que representa um usuário.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Obtém ou define o ID do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define o e-mail do usuário.
        /// </summary>
        public string Email { get; set; }
    }
}
