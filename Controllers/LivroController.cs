using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenLibrary.Entities;
using OpenLibrary.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository) 
        {
            _livroRepository = livroRepository;
        }

        // GET: api/<LivroController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroRepository.GetAllAsync();
            return Ok(livros);
        }

        // GET api/<LivroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null)
                return NotFound(new { Message = $"Livro Com Id: {id} não foi encontrando." });

            return Ok(livro);
        }

        // GET api/<LivroController>/Titulo/titulo
        [HttpGet("Titulo/{titulo}")]
        public async Task<IActionResult> GetByTitulo(string titulo)
        {
            var livro = await _livroRepository.GetByTituloAsync(titulo);
            if (livro == null)
                return NotFound(new { Message = $"Livro Com Titulo: {titulo} não foi encontrando." });

            return Ok(livro);
        }


        // POST api/<LivroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro NewLivro)
        {
            await _livroRepository.PostAsync(NewLivro);
            return CreatedAtAction(nameof(GetById), new { id = NewLivro.Id }, NewLivro);
        }

        // PUT api/<LivroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Livro UpdateLivro)
        {
            if (UpdateLivro == null)
                return BadRequest("Corpo da requisição inválido.");

            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null)
                return NotFound(new { Message = $"Livro Com Id: {id} não foi encontrando." });

            livro.Titulo = UpdateLivro.Titulo;
            livro.Autor = UpdateLivro.Autor;
            livro.Genero = UpdateLivro.Genero;

            await _livroRepository.UpdateAsync(livro);
            return Ok(new { Message = "Livro atualizado com sucesso!", livro });
        }

        // DELETE api/<LivroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null)
                return NotFound(new { Message = $"Livro com Id: {id} não foi encontrado." });
          
            await _livroRepository.DeleteAsync(id);
            return Ok(new { Message = $"Livro com Id {id} foi removido com sucesso!" });
        }
    }
}
