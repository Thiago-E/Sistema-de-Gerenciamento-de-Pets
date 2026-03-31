using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;
using GerenciamentoDePets.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePets.Controller;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private IPetRepository _petRepository;

    public PetController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    /// <summary>
    /// Endpoint da API que cadastra um novo pet
    /// </summary>
    /// <param name="petDTO">Nome do novo pet a ser cadastrado</param>
    /// <returns>Status code 201 e um pet cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PetDTO petDTO)
    {
        if (string.IsNullOrWhiteSpace(petDTO.Nome))
            return BadRequest("É obrigatório que o pet tenha um nome");

        Pet novoPet = new Pet();

        novoPet.IdPet = Guid.NewGuid();

        // 📸 Upload da imagem
        if (petDTO.Imagem != null && petDTO.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(petDTO.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/images";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await petDTO.Imagem.CopyToAsync(stream);
            }

            novoPet.Imagem = nomeArquivo;
        }

        // 🐶 Dados do Pet
        novoPet.Nome = petDTO.Nome;
        novoPet.Idade = petDTO.Idade.ToString();
        novoPet.Peso = Convert.ToDouble(petDTO.Peso);
        novoPet.IdResponsavel = petDTO.IdResponsavel;
        novoPet.IdTipoPet = petDTO.IdTipoPet;

        try
        {
            _petRepository .CadastrarPet(novoPet);

            return StatusCode(201, novoPet);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                erro = ex.Message,
                detalhe = ex.InnerException?.Message
            });
        }
    }

    /// <summary>
    /// Endpoint da API que lista todos os pets
    /// </summary>
    /// <returns>Status code 200 e lista de pets</returns>
        [HttpGet]
        public IActionResult Listar()
        {

        try
        {
            return Ok(_petRepository.ListarPets());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

         }


    /// <summary>
    /// Endpoint da API que busca um pet pelo seu id
    /// </summary>
    /// <param name="id">Id do pet a ser buscado</param>
    /// <returns>Status code 200 e o pet especifico buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
          return Ok(_petRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
     }

    /// <summary>
    /// Endpoint da API que atualiza um pet especifico pelo id
    /// </summary>
    /// <param name="id">Id do pet a ser atualizado</param>
    /// <param name="petDTO">Nome do pet a ser atualizado pelo id</param>
    /// <returns>Status code 204 e o pet atualizado pelo seu id</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPet(Guid id, [FromForm] AtualizarPetDTO petDTO)
    {
        var petExistente = _petRepository.BuscarPorId(id);

        if (petExistente == null)
            return NotFound();

        // 🐶 Atualizando dados
        petExistente.Nome = petDTO.Nome ?? petExistente.Nome;
        petExistente.Idade = petDTO.Idade ?? petExistente.Idade;



        // Conversão segura do peso (caso venha string)
        if (!double.TryParse(petDTO.Peso, out double pesoConvertido))
            return BadRequest("Peso inválido");


        // 📸 Atualização da imagem
        if (petDTO.Imagem != null && petDTO.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(petDTO.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await petDTO.Imagem.CopyToAsync(stream);
            }

            petExistente.Imagem = nomeArquivo;
        }

        _petRepository.AtualizarPet(id, petExistente);

        return NoContent();
    }


    /// <summary>
    /// Endpoint da API que deleta um pet pelo seu id
    /// </summary>
    /// <param name="id">Id do pet a ser deletado</param>
    /// <returns>Status code 204 e o pet deletado</returns>
    [HttpDelete("{id}")]
      public IActionResult Deletar(Guid id)
      {
          try
          {
              _petRepository.DeletarPet(id);
              return NoContent();
          }
          catch (Exception erro)
          {
              return BadRequest(erro.Message);
          }
    }
}