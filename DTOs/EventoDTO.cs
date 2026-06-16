namespace WebApiCafeteria.DTOs;

public class EventoDTO
{
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataEvento { get; set; }

    public string? LocalEvento { get; set; }

    public int Vagas { get; set; }

    public string? Banner { get; set; }
}