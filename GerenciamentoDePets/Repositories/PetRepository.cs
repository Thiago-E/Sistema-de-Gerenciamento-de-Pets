using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Repositories;

public class PetRepository : IPetRepository
{
    private readonly GerenciamentoDePetsContext _context;

    public PetRepository(GerenciamentoDePetsContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que busca o pet pelo seu id
    /// </summary>
    /// <param name="id">Id do pet a ser buscado</param>
    /// <returns>Pet buscado pelo id</returns>
    public Pet? BuscarPorId(Guid id)
    {
        return _context.Pets.FirstOrDefault(p => p.IdPet == id);
    }

    /// <summary>
    /// Metodo que lista todos os pets
    /// </summary>
    /// <returns>Lista de todos os pets cadastrado</returns>
    public List<Pet> ListarPets()
    {
        return _context.Pets.ToList();
    }

    /// <summary>
    /// Metodo que cadastra um novo pet
    /// </summary>
    /// <param name="pet">Nome do pet cadastrado</param>
    public void CadastrarPet(Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
    }

   

    /// <summary>
    /// Metodo que deleta pet pelo id
    /// </summary>
    /// <param name="id">Nome do pet a ser deletado pelo id</param>
    public void DeletarPet(Guid id)
    {
        var pet = _context.Pets.Find(id);

        if (pet != null)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }

   
    /// <summary>
    /// Metodo que atualiza o pet pelo id
    /// </summary>
    /// <param name="id">Id do pet a ser atualizado</param>
    /// <param name="pet">Nome do pet a ser atualizado</param>
    public void AtualizarPet(Guid id, Pet pet)
    {
        var petExistente = _context.Pets.Find(id);

        if (petExistente != null)
        {
            petExistente.Nome = string.IsNullOrWhiteSpace(pet.Nome)
                ? petExistente.Nome
                : pet.Nome;

            petExistente.Peso = pet.Peso != 0
                ? pet.Peso
                : petExistente.Peso;

            petExistente.Idade = string.IsNullOrWhiteSpace(pet.Idade)
                ? petExistente.Idade
                : pet.Idade;

            petExistente.Imagem = string.IsNullOrWhiteSpace(pet.Imagem)
                ? petExistente.Imagem
                : pet.Imagem;

            petExistente.IdResponsavel = pet.IdResponsavel ?? petExistente.IdResponsavel;

            petExistente.IdTipoPet = pet.IdTipoPet ?? petExistente.IdTipoPet;

            _context.SaveChanges();
        }
    }
}