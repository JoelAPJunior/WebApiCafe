using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Funcionario>> GetById(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);

        if (funcionario == null)
            return NotFound();

        return funcionario;
    }

    [HttpPost]
    public async Task<ActionResult> Post(FuncionarioDTO dto)
    {
        Funcionario funcionario = new Funcionario
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Funcao = dto.Funcao,
            Senha = dto.Senha
        };

        _context.Funcionarios.Add(funcionario);

        await _context.SaveChangesAsync();

        return Ok(funcionario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, FuncionarioDTO dto)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);

        if (funcionario == null)
            return NotFound();

        funcionario.Nome = dto.Nome;
        funcionario.Cpf = dto.Cpf;
        funcionario.Email = dto.Email;
        funcionario.Telefone = dto.Telefone;
        funcionario.Funcao = dto.Funcao;
        funcionario.Senha = dto.Senha;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);

        if (funcionario == null)
            return NotFound();

        _context.Funcionarios.Remove(funcionario);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}