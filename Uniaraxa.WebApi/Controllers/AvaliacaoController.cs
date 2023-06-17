using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas às Avaliações.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe AvaliacaoController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public AvaliacaoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtém todas as Avaliações.
        /// </summary>
        /// <returns>Um IActionResult contendo a lista de Avaliações.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Avaliacao.GetAllAsync();
            return Ok(data);
        }

        /// <summary>
        /// Obtém uma Avaliação pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Avaliação.</param>
        /// <returns>Um IActionResult contendo a Avaliação encontrada ou NotFound se não encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Avaliacao.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona uma nova Avaliação.
        /// </summary>
        /// <param name="avaliacao">O objeto Avaliação contendo os dados da nova Avaliação.</param>
        /// <returns>Um IActionResult contendo a Avaliação adicionada.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Avaliacao avaliacao)
        {
            var data = await unitOfWork.Avaliacao.AddAsync(avaliacao);
            return Ok(data);
        }

        /// <summary>
        /// Exclui uma Avaliação pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Avaliação a ser excluída.</param>
        /// <returns>Um IActionResult indicando o resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Avaliacao.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// Atualiza uma Avaliação existente.
        /// </summary>
        /// <param name="avaliacao">O objeto Avaliação contendo os dados atualizados da Avaliação.</param>
        /// <returns>Um IActionResult indicando o resultado da atualização.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Avaliacao avaliacao)
        {
            var data = await unitOfWork.Avaliacao.UpdateAsync(avaliacao);
            return Ok(data);
        }
    }
}
