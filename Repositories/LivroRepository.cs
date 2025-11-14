using Microsoft.EntityFrameworkCore;
using OpenLibrary.Data;
using OpenLibrary.Entities;
using OpenLibrary.Interfaces;
using System;

namespace OpenLibrary.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroContext _context;
        public LivroRepository(LivroContext context)
        {
            _context = context;
        }


        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<Livro?> GetByTituloAsync(string titulo) 
        { 
        
            return await _context.Livros.FirstOrDefaultAsync(x => x.Titulo.ToLower() == titulo.ToLower());
        }

        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task PostAsync(Livro NewLivro)
        {
            await _context.Livros.AddAsync(NewLivro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var livro = await GetByIdAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
