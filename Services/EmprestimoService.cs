using ApiBiblioteca.Data;
using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Services
{
    public class EmprestimoService
    {
        private readonly BibliotecaDbContext _context;

        public EmprestimoService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Emprestimo>> ListarTodosAsync()
        {
            return await _context.Emprestimos.Include(e => e.Usuario).Include(e => e.Livro).ToListAsync();
        }

        public async Task<Emprestimo?> BuscarPorIdAsync(int id)
        {
            return await _context.Emprestimos
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<string> CriarAsync(Emprestimo emprestimo)
        {
            var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
            var usuario = await _context.Usuarios.FindAsync(emprestimo.UsuarioId);

            if (livro == null) return "Livro não encontrado.";
            if (usuario == null) return "Usuário não encontrado.";
            if (livro.QuantidadeDisponivel <= 0) return "Livro indisponível.";

            livro.QuantidadeDisponivel--;

            emprestimo.DataEmprestimo = DateTime.Now;
            emprestimo.DataDevolucaoPrevista = DateTime.Now.AddDays(7);
            emprestimo.Multa = 0;

            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
            return "Empréstimo registrado com sucesso!";
        }

        public async Task<string> RegistrarDevolucaoAsync(int id)
        {
            var emprestimo = await _context.Emprestimos.Include(e => e.Livro).FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null) return "Empréstimo não encontrado.";
            if (emprestimo.DataDevolucaoReal != null) return "Já devolvido.";

            emprestimo.DataDevolucaoReal = DateTime.Now;

            if (emprestimo.DataDevolucaoReal > emprestimo.DataDevolucaoPrevista)
            {
                var diasAtraso = (emprestimo.DataDevolucaoReal.Value - emprestimo.DataDevolucaoPrevista).Days;
                emprestimo.Multa = diasAtraso * 2;
            }

            if (emprestimo.Livro != null)
            {
                emprestimo.Livro.QuantidadeDisponivel++;
            }

            await _context.SaveChangesAsync();
            return "Devolução registrada com sucesso!";
        }
    }
}