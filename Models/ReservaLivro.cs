using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCafeteria.Models;

[Table("reservas_livros")]
public class ReservaLivro
{
    public int Id { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("livro_id")]
    public int LivroId { get; set; }

    [Column("data_reserva")]
    public DateTime DataReserva { get; set; }

    [Column("status_reserva")]
    public string StatusReserva { get; set; }

    public Cliente Cliente { get; set; }

    public Livro Livro { get; set; }
}