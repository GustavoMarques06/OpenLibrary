using OpenLibrary.Entities;

namespace OpenLibrary.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> GetByIdAsync(int id);
        Task<Livro> GetByTituloAsync(string titulo);
        Task<IEnumerable<Livro>> GetAllAsync();
        Task PostAsync(Livro livro);
        Task UpdateAsync(Livro livro);
        Task DeleteAsync(int id);
    }
}
