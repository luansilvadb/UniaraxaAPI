using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas às Sugestões.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SugestaoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe SugestaoController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public SugestaoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtém todas as Sugestões.
        /// </summary>
        /// <returns>Um IActionResult contendo a lista de Sugestões.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Sugestao.GetAllAsync();
            return Ok(data);
        }

        /// <summary>
        /// Obtém uma Sugestão pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Sugestão.</param>
        /// <returns>Um IActionResult contendo a Sugestão encontrada ou NotFound se não encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Sugestao.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona uma nova Sugestão.
        /// </summary>
        /// <param name="sugestao">O objeto Sugestão contendo os dados da nova Sugestão.</param>
        /// <returns>Um IActionResult contendo a Sugestão adicionada.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Sugestao sugestao)
        {
            var data = await unitOfWork.Sugestao.AddAsync(sugestao);
            return Ok(data);
        }

        /// <summary>
        /// Exclui uma Sugestão pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da Sugestão a ser excluída.</param>
        /// <returns>Um IActionResult indicando o resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Sugestao.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// Atualiza uma Sugestão existente.
        /// </summary>
        /// <param name="sugestao">O objeto Sugestão contendo os dados atualizados da Sugestão.</param>
        /// <returns>Um IActionResult indicando o resultado da atualização.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Sugestao sugestao)
        {
            var data = await unitOfWork.Sugestao.UpdateAsync(sugestao);
            return Ok(data);
        }
    }
}
