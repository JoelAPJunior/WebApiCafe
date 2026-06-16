using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCafeteria.Models;

[Table("participacoes_eventos")]
public class ParticipacaoEvento
{
    public int Id { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("evento_id")]
    public int EventoId { get; set; }

    [Column("data_inscricao")]
    public DateTime DataInscricao { get; set; }

    public Cliente Cliente { get; set; }

    public Evento Evento { get; set; }
}