using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCafeteria.Models;

public class Evento
{
    [Key]
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    [Column("data_evento")]
    public DateTime DataEvento { get; set; }

    [Column("local_evento")]
    public string? LocalEvento { get; set; }

    public int Vagas { get; set; }

    public string? Banner { get; set; }
}