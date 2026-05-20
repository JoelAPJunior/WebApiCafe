namespace WebApiCafeteria.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public int Ano { get; set; }

        public int QuantidadeEstoque { get; set; }

        public string? ImagemCapa { get; set; }
    }
}
