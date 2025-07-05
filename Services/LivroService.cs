using ApiBiblioteca.Data;
using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Services
{
    public class LivroService
    {
        private readonly BibliotecaDbContext _context;

        public LivroService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> ListarTodosAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> BuscarPorIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<Livro> CriarAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<bool> AtualizarAsync(int id, Livro livroAtualizado)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            livro.Titulo = livroAtualizado.Titulo;
            livro.Autor = livroAtualizado.Autor;
            livro.Genero = livroAtualizado.Genero;
            livro.QuantidadeDisponivel = livroAtualizado.QuantidadeDisponivel;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}