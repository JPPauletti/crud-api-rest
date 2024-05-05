using Microsoft.EntityFrameworkCore;
using Refit;
using TaskSystem.Data;
using TaskSystem.Integration;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Refit;
using TaskSystem.Repositories;
using TaskSystem.Repositories.Interfaces;

namespace SistemaDeTarefas
{
    /// <summary>
    /// Classe principal que contém o método de entrada da aplicação.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método de entrada da aplicação.
        /// </summary>
        /// <param name="args">Argumentos da linha de comando.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner.

            builder.Services.AddControllers();
            // Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TaskSystemDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            var app = builder.Build();

            // Configura o pipeline de solicitação HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
