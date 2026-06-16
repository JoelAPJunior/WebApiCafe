using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCafeteria.Models;

public class Livro
{
    [Key]
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Autor { get; set; }

    public int Ano { get; set; }

    [Column("quantidade_estoque")]
    public int QuantidadeEstoque { get; set; }

    [Column("imagem_capa")]
    public string? ImagemCapa { get; set; }
}