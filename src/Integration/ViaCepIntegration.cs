using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Refit;
using TaskSystem.Integration.Response;

namespace TaskSystem.Integration
{
    /// <summary>
    /// Classe responsável por integrar com o serviço ViaCep utilizando Refit.
    /// </summary>
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        /// <summary>
        /// Construtor da classe ViaCepIntegration.
        /// </summary>
        /// <param name="viaCepIntegrationRefit">Instância da interface IViaCepIntegrationRefit.</param>
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        /// <summary>
        /// Obtém os dados do endereço correspondente a um CEP fornecido utilizando Refit para realizar a integração.
        /// </summary>
        /// <param name="cep">CEP do endereço desejado.</param>
        /// <returns>Objeto contendo os dados do endereço correspondente ao CEP.</returns>
        public async Task<ViaCepResponse> GetViaCepData(string cep)
        {
            // Chama o método da interface IViaCepIntegrationRefit para obter os dados do endereço.
            var responseData = await _viaCepIntegrationRefit.GetViaCepData(cep);

            // Verifica se a resposta foi bem-sucedida e retorna os dados do endereço, se disponíveis.
            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
