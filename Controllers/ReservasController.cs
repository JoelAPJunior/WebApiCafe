using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> Reservar(ReservaLivroDTO dto)
    {
        var cliente =
            await _context.Clientes.FindAsync(dto.ClienteId);

        if (cliente == null)
            return BadRequest("Cliente não encontrado.");

        var livro =
            await _context.Livros.FindAsync(dto.LivroId);

        if (livro == null)
            return BadRequest("Livro não encontrado.");

        if (livro.QuantidadeEstoque <= 0)
            return BadRequest("Livro sem estoque.");

        ReservaLivro reserva = new ReservaLivro
        {
            ClienteId = dto.ClienteId,
            LivroId = dto.LivroId,
            DataReserva = DateTime.Now,
            StatusReserva = "PENDENTE"
        };

        _context.ReservasLivros.Add(reserva);

        livro.QuantidadeEstoque--;

        await _context.SaveChangesAsync();

        return Ok(reserva);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaLivro>>>
Get()
    {
        return await _context.ReservasLivros
            .Include(r => r.Cliente)
            .Include(r => r.Livro)
            .ToListAsync();
    }

    [HttpPut("{id}/confirmar")]
    public async Task<ActionResult> Confirmar(int id)
    {
        var reserva =
            await _context.ReservasLivros.FindAsync(id);

        if (reserva == null)
            return NotFound();

        reserva.StatusReserva = "RETIRADO";

        await _context.SaveChangesAsync();

        return Ok(reserva);
    }

    [HttpPut("{id}/cancelar")]
    public async Task<ActionResult> Cancelar(int id)
    {
        var reserva =
            await _context.ReservasLivros.FindAsync(id);

        if (reserva == null)
            return NotFound();

        reserva.StatusReserva = "CANCELADO";

        await _context.SaveChangesAsync();

        return Ok(reserva);
    }

}