namespace WebApiCafeteria.DTOs;

public class LivroDTO
{
    public string Titulo { get; set; }

    public string Autor { get; set; }

    public int Ano { get; set; }

    public int QuantidadeEstoque { get; set; }

    public string? ImagemCapa { get; set; }
}