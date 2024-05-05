using Refit;
using TaskSystem.Integration.Response;

namespace TaskSystem.Integration.Refit
{
    /// <summary>
    /// Interface para integração com o serviço ViaCep utilizando Refit para realizar chamadas HTTP.
    /// </summary>
    public interface IViaCepIntegrationRefit
    {
        /// <summary>
        /// Obtém os dados do endereço correspondente a um CEP fornecido.
        /// </summary>
        /// <param name="cep">CEP do endereço desejado.</param>
        /// <returns>Resposta HTTP contendo os dados do endereço correspondente ao CEP.</returns>
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetViaCepData(string cep);
    }
}
