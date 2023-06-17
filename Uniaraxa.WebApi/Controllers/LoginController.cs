using System;
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
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Inicializa uma nova instância da classe FuncionarioController.
        /// </summary>
        /// <param name="unitOfWork">A unidade de trabalho utilizada pelo controller.</param>
        public LoginController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Autentica um funcionário com base em seu login e senha.
        /// </summary>
        /// <param name="request">O objeto LoginRequest contendo os dados de login do funcionário.</param>
        /// <returns>Um IActionResult indicando o resultado da autenticação.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var funcionario = await unitOfWork.Funcionario.ValidateCredentialsAsync(request.Cpf, request.Senha);
                if (funcionario == null)
                {
                    return Unauthorized("Cpf ou senha inválidos");
                }

                // Aqui você pode criar um cookie de sessão ou token JWT para o funcionário

                return Ok(new { success = true, message = "Login realizado com sucesso" });
            }
            catch (InvalidOperationException)
            {
                return BadRequest(new { success = false, message = "Mais de um usuário com o mesmo CPF e senha encontrado. Por favor, contate o administrador." });
            }
        }



    }
}