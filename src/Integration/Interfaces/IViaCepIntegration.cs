using TaskSystem.Integration.Response;

namespace TaskSystem.Integration.Interfaces
{
    /// <summary>
    /// Interface para integração com o serviço ViaCep para obter dados de endereços a partir de um CEP.
    /// </summary>
    public interface IViaCepIntegration
    {
        /// <summary>
        /// Obtém os dados do endereço correspondente a um CEP fornecido.
        /// </summary>
        /// <param name="cep">CEP do endereço desejado.</param>
        /// <returns>Objeto contendo os dados do endereço correspondente ao CEP.</returns>
        Task<ViaCepResponse> GetViaCepData(string cep);
    }
}
