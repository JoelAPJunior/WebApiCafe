using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Models;

namespace WebApiCafeteria.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Funcionario> Funcionarios { get; set; }

    public DbSet<Livro> Livros { get; set; }

    public DbSet<Evento> Eventos { get; set; }

    public DbSet<ReservaLivro> ReservasLivros { get; set; }

    public DbSet<ParticipacaoEvento> ParticipacoesEventos { get; set; }
}