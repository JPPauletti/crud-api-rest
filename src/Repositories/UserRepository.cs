using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    /// <summary>
    /// Classe que implementa o repositório de usuários.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        /// <summary>
        /// Construtor da classe UserRepository.
        /// </summary>
        /// <param name="taskSystemDBContext">Contexto do banco de dados da aplicação.</param>
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        /// <inheritdoc/>
        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        /// <inheritdoc/>
        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"User for the Id:{id} was not found in the database.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        /// <inheritdoc/>
        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"User for the Id:{id} was not found in the database.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
