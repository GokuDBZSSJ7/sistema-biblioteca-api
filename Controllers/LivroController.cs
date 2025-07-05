using ApiBiblioteca.Models;
using ApiBiblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var livros = await _livroService.ListarTodosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroService.BuscarPorIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro livro)
        {
            var novoLivro = await _livroService.CriarAsync(livro);
            return CreatedAtAction(nameof(GetById), new { id = novoLivro.Id }, novoLivro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Livro livro)
        {
            var atualizado = await _livroService.AtualizarAsync(id, livro);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _livroService.DeletarAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}