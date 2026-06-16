using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public LivrosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> Get()
    {
        return await _context.Livros.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetById(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            return NotFound();

        return livro;
    }

    [HttpPost]
    public async Task<ActionResult> Post(LivroDTO dto)
    {
        Livro livro = new Livro
        {
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Ano = dto.Ano,
            QuantidadeEstoque = dto.QuantidadeEstoque,
            ImagemCapa = dto.ImagemCapa
        };

        _context.Livros.Add(livro);

        await _context.SaveChangesAsync();

        return Ok(livro);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, LivroDTO dto)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            return NotFound();

        livro.Titulo = dto.Titulo;
        livro.Autor = dto.Autor;
        livro.Ano = dto.Ano;
        livro.QuantidadeEstoque = dto.QuantidadeEstoque;
        livro.ImagemCapa = dto.ImagemCapa;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            return NotFound();

        _context.Livros.Remove(livro);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}