using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipacoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ParticipacoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult>
    Inscrever(ParticipacaoEventoDTO dto)
    {
        var cliente =
            await _context.Clientes.FindAsync(dto.ClienteId);

        if (cliente == null)
            return BadRequest("Cliente não encontrado.");

        var evento =
            await _context.Eventos.FindAsync(dto.EventoId);

        if (evento == null)
            return BadRequest("Evento não encontrado.");

        bool jaInscrito =
            await _context.ParticipacoesEventos
            .AnyAsync(p =>
                p.ClienteId == dto.ClienteId &&
                p.EventoId == dto.EventoId);

        if (jaInscrito)
            return BadRequest("Cliente já inscrito.");

        int quantidadeInscritos =
            await _context.ParticipacoesEventos
            .CountAsync(p =>
                p.EventoId == dto.EventoId);

        if (quantidadeInscritos >= evento.Vagas)
            return BadRequest("Evento lotado.");

        ParticipacaoEvento participacao =
            new ParticipacaoEvento
            {
                ClienteId = dto.ClienteId,
                EventoId = dto.EventoId,
                DataInscricao = DateTime.Now
            };

        _context.ParticipacoesEventos.Add(participacao);

        await _context.SaveChangesAsync();

        return Ok(participacao);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParticipacaoEvento>>>
Get()
    {
        return await _context.ParticipacoesEventos
            .Include(p => p.Cliente)
            .Include(p => p.Evento)
            .ToListAsync();
    }
    


}