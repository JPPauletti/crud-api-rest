using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Response;

namespace TaskSystem.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a CEP.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;

        /// <summary>
        /// Construtor da classe CepController.
        /// </summary>
        /// <param name="viaCepIntegration">Instância da classe de integração com o serviço ViaCep.</param>
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        /// <summary>
        /// Obtém os dados relacionados a um endereço a partir de um CEP fornecido.
        /// </summary>
        /// <param name="cep">CEP do endereço desejado.</param>
        /// <returns>Objeto contendo os dados do endereço correspondente ao CEP.</returns>
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListAddressData(string cep)
        {
            // Obtém os dados do endereço a partir do serviço ViaCep.
            var responseData = await _viaCepIntegration.GetViaCepData(cep);

            // Verifica se os dados foram encontrados.
            if (responseData == null)
            {
                return BadRequest("Cep not found");
            }

            return Ok(responseData);
        }
    }
}
