using ApiBiblioteca.Models;
using ApiBiblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoService _emprestimoService;

        public EmprestimoController(EmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var emprestimos = await _emprestimoService.ListarTodosAsync();
            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var emprestimo = await _emprestimoService.BuscarPorIdAsync(id);
            if (emprestimo == null) return NotFound();
            return Ok(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Emprestimo emprestimo)
        {
            var resultado = await _emprestimoService.CriarAsync(emprestimo);
            return Ok(new { mensagem = resultado });
        }

        [HttpPut("devolver/{id}")]
        public async Task<IActionResult> RegistrarDevolucao(int id)
        {
            var resultado = await _emprestimoService.RegistrarDevolucaoAsync(id);
            return Ok(new { mensagem = resultado });
        }

    }
}