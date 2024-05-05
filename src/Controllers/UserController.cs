using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor da classe UserController.
        /// </summary>
        /// <param name="userRepository">Instância da interface IUserRepository.</param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        } 

        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de todos os usuários.</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário desejado.</param>
        /// <returns>Usuário correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        /// <summary>
        /// Registra um novo usuário.
        /// </summary>
        /// <param name="userModel">Objeto contendo os dados do usuário a ser registrado.</param>
        /// <returns>Usuário registrado.</returns>
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Add(userModel);
            return Ok(user);
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="userModel">Objeto contendo os novos dados do usuário.</param>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <returns>Usuário atualizado.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);
            return Ok(user);
        }

        /// <summary>
        /// Exclui um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Indicação se a exclusão foi bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _userRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
