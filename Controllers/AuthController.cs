using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCafeteria.Data;
using WebApiCafeteria.DTOs;

namespace WebApiCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDTO dto)
    {
        var funcionario = await _context.Funcionarios
            .FirstOrDefaultAsync(f =>
                f.Email == dto.Email &&
                f.Senha == dto.Senha);

        if (funcionario == null)
        {
            return Unauthorized("Email ou senha inválidos.");
        }

        return Ok(new
        {
            funcionario.Id,
            funcionario.Nome,
            funcionario.Email,
            funcionario.Funcao
        });
    }
}