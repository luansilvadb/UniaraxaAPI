using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas às Campanhas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe CampanhaController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public CampanhaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtém todas as Campanhas.
        /// </summary>
        /// <returns>Um IActionResult contendo a lista de Campanhas.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Campanha.GetAllAsync();
            return Ok(data);
        }

        /// <summary>
        /// Obtém uma Campanha pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Campanha.</param>
        /// <returns>Um IActionResult contendo a Campanha encontrada ou NotFound se não encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Campanha.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona uma nova Campanha.
        /// </summary>
        /// <param name="campanha">O objeto Campanha contendo os dados da nova Campanha.</param>
        /// <returns>Um IActionResult contendo a Campanha adicionada.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Campanha campanha)
        {
            var data = await unitOfWork.Campanha.AddAsync(campanha);
            return Ok(data);
        }

        /// <summary>
        /// Exclui uma Campanha pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Campanha a ser excluída.</param>
        /// <returns>Um IActionResult indicando o resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Campanha.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// Atualiza uma Campanha existente.
        /// </summary>
        /// <param name="campanha">O objeto Campanha contendo os dados atualizados da Campanha.</param>
        /// <returns>Um IActionResult indicando o resultado da atualização.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Campanha campanha)
        {
            var data = await unitOfWork.Campanha.UpdateAsync(campanha);
            return Ok(data);
        }
    }
}
