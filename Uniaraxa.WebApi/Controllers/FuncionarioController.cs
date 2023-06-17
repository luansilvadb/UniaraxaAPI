using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas aos funcionários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe FuncionarioController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public FuncionarioController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Obtém todos os funcionários.
        /// </summary>
        /// <returns>Um IActionResult contendo a lista de funcionários.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Funcionario.GetAllAsync();
            return Ok(data);
        }
        /// <summary>
        /// Obtém um funcionário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do funcionário.</param>
        /// <returns>Um IActionResult contendo o funcionário encontrado ou NotFound se não encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Funcionario.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        /// <summary>
        /// Adiciona um novo funcionário.
        /// </summary>
        /// <param name="funcionario">O objeto Funcionario contendo os dados do novo funcionário.</param>
        /// <returns>Um IActionResult contendo o funcionário adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Funcionario funcionario)
        {
            var data = await unitOfWork.Funcionario.AddAsync(funcionario);
            return Ok(data);
        }
        /// <summary>
        /// Exclui um funcionário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do funcionário a ser excluído.</param>
        /// <returns>Um IActionResult indicando o resultado da exclusão.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Funcionario.DeleteAsync(id);
            return Ok(data);
        }
        /// <summary>
        /// Atualiza um funcionário existente.
        /// </summary>
        /// <param name="funcionario">O objeto Funcionario contendo os dados atualizados do funcionário.</param>
        /// <returns>Um IActionResult indicando o resultado da atualização.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Funcionario funcionario)
        {
            var data = await unitOfWork.Funcionario.UpdateAsync(funcionario);
            return Ok(data);
        }
    }
}