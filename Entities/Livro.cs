using System.ComponentModel.DataAnnotations;

namespace OpenLibrary.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Titulo obrigatorio.")]
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
    }
}
