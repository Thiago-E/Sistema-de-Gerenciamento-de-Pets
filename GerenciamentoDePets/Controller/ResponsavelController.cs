using GerenciamentoDePets.Interfaces;
using Microsoft.AspNetCore.Mvc;
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


    /// <summary>
    /// Endpoint da API que busca listar os responsaveis dos pets
    /// </summary>
    /// <returns>Status code 200 e lista de responsaveis</returns>
    [HttpGet]
    public ActionResult Listar()
    {
        try
        {
            return Ok(_responsavelRepository.Listar());
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que cadastra um responsavel
    /// </summary>
    /// <param name="responsavel">Nome do responsavel a ser cadastrado</param>
    /// <returns>Status code 201 e responsavel novo cadastrado</returns>
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

    /// <summary>
    /// Endpoint da API que atualiza um responsavel de pet
    /// </summary>
    /// <param name="id">Id do responsavel a ser atualizado</param>
    /// <param name="responsavel">Nome do responsavel a ser atualizado</param>
    /// <returns>Status code 204 e responsavel do pet atualizado</returns>
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
