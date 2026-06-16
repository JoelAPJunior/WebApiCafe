using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> Get()
    {
        return await _context.Eventos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> GetById(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);

        if (evento == null)
            return NotFound();

        return evento;
    }

    [HttpPost]
    public async Task<ActionResult> Post(EventoDTO dto)
    {
        Evento evento = new Evento
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            DataEvento = dto.DataEvento,
            LocalEvento = dto.LocalEvento,
            Vagas = dto.Vagas,
            Banner = dto.Banner
        };

        _context.Eventos.Add(evento);

        await _context.SaveChangesAsync();

        return Ok(evento);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, EventoDTO dto)
    {
        var evento = await _context.Eventos.FindAsync(id);

        if (evento == null)
            return NotFound();

        evento.Titulo = dto.Titulo;
        evento.Descricao = dto.Descricao;
        evento.DataEvento = dto.DataEvento;
        evento.LocalEvento = dto.LocalEvento;
        evento.Vagas = dto.Vagas;
        evento.Banner = dto.Banner;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);

        if (evento == null)
            return NotFound();

        _context.Eventos.Remove(evento);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}