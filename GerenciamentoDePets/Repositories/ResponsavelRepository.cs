using Microsoft.AspNetCore.Mvc;
using GerenciamentoDePets.DTO;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Controller;

[Route("api/[controller]")]
[ApiController]
public class ResponsavelController : ControllerBase
{
    private readonly IResponsavelRepository _repository;

    public ResponsavelController(IResponsavelRepository repository)
    {
        _repository = repository;
    }

    // GET: api/responsavel
    [HttpGet]
    public ActionResult Get()
    {
        try
        {
            return Ok(_repository.Listar());
        }
        catch (Exception error)
        {
         return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public ActionResult Post( ResponsavelDTO dto)
    {
        var responsavel = new Responsavel
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Telefone = dto.Telefone
        };

        _repository.CadastrarResponsavel(responsavel);

        return Created("", dto);
    }

    
    [HttpPut("{id}")]
    public ActionResult Put(Guid id,  ResponsavelDTO dto)
    {
        var responsavel = new Responsavel
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Telefone = dto.Telefone
        };

        _repository.AtualizarResponsavel(id, responsavel);

        return NoContent();
    }
}