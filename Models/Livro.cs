using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Genero { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser 0 ou mais.")]
        public int QuantidadeDisponivel { get; set; }
    }
}