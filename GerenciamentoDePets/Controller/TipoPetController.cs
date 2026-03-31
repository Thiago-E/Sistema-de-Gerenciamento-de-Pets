using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using GerenciamentoDePets.DTO;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePets.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        private readonly ITipoPetRepository _tipoPetRepository;

        public TipoPetController(ITipoPetRepository context)
        {
            _tipoPetRepository = context;
        }


        /// <summary>
        /// Lista todos os tipos de pets cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoPetRepository.Listar());
        }


        /// <summary>
        /// Endpoind da API que faz chamada para o metódo de cadastrar um tipo de Pet
        /// </summary>
        /// <param name="tipoPet">Tipo de pet a ser cadastrado</param>
        /// <returns>Status code 201 e o tipo de pet</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoPet tipoPet)
        {
            _tipoPetRepository.CadastrarTipoPet(tipoPet);
            return Ok(tipoPet);
        }



        /// <summary>
        /// Endpoind da API que faz chamada para o metódo de Atualizar um tipo de Pet
        /// </summary>
        /// <param name="id">Id do Tipo Pet</param>
        /// <param name="TipoPetDTO"></param>
        /// <returns>Status Code 204 e contato atualizado</returns>
        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, TipoPetDTO TipoPetDTO)
        {
            try
            {
                var TipoPetAtualizado = new TipoPet
                {
                    Especie = TipoPetDTO.Especie 

                };
                _tipoPetRepository.AtualizarTipoPet(id, TipoPetAtualizado);
                return StatusCode(204, TipoPetDTO);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }


        }
    }
}
