using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult> Post(ClienteDTO dto)
    {
        Cliente cliente = new Cliente
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Endereco = dto.Endereco
        };

        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, ClienteDTO dto)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        cliente.Nome = dto.Nome;
        cliente.Cpf = dto.Cpf;
        cliente.Email = dto.Email;
        cliente.Telefone = dto.Telefone;
        cliente.Endereco = dto.Endereco;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}