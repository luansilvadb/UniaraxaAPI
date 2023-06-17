using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas aos Avaliadores.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliadorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe AvaliadorController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public AvaliadorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtém todos os Avaliadores.
        /// </summary>
        /// <returns>Um IActionResult contendo a lista de Avaliadores.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Avaliador.GetAllAsync();
            return Ok(data);
        }

        /// <summary>
        /// Obtém um Avaliador pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do Avaliador.</param>
        /// <returns>Um IActionResult contendo o Avaliador encontrado ou NotFound se não encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Avaliador.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona um novo Avaliador.
        /// </summary>
        /// <param name="avaliador">O objeto Avaliador contendo os dados do novo Avaliador.</param>
        /// <returns>Um IActionResult contendo o Avaliador adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Avaliador avaliador)
        {
            var data = await unitOfWork.Avaliador.AddAsync(avaliador);
            return Ok(data);
        }

        /// <summary>
        /// Exclui um Avaliador pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do Avaliador a ser excluído.</param>
        /// <returns>Um IActionResult indicando o resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Avaliador.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// Atualiza um Avaliador existente.
        /// </summary>
        /// <param name="avaliador">O objeto Avaliador contendo os dados atualizados do Avaliador.</param>
        /// <returns>Um IActionResult indicando o resultado da atualização.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Avaliador avaliador)
        {
            var data = await unitOfWork.Avaliador.UpdateAsync(avaliador);
            return Ok(data);
        }
    }
}
