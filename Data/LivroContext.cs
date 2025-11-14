using Microsoft.EntityFrameworkCore;
using OpenLibrary.Entities;

namespace OpenLibrary.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasKey(x => x.Id);
        }
    }
}
