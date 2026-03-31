using GerenciamentoDePets.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDePets.DTO;
using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Controller;

[Route("api/[controller]")]
[ApiController]
public class ResponsavelController : ControllerBase
{
    private readonly IResponsavelRepository _responsavelRepository;

    public ResponsavelController(IResponsavelRepository repository)
    {
        _responsavelRepository = repository;
    }


    [HttpGet]
    public ActionResult Listar()
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
    public ActionResult CadastrarResponsavel(Responsavel responsavel)
    {
        try
        {
            _responsavelRepository.CadastrarResponsavel(responsavel);
            return StatusCode(201, responsavel);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpPut("{id}")]
    public ActionResult AtualizarResponsavel(Guid id, Responsavel responsavel)
    {
        try
        {
            var responsavelExistente = new Responsavel
            {
                Nome = responsavel.Nome,
                Cpf = responsavel.Cpf,
                Telefone = responsavel.Telefone,
            };
            _responsavelRepository.AtualizarResponsavel(id, responsavelExistente);
            return Ok(responsavelExistente);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
