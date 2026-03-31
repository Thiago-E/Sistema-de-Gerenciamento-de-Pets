using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;
using System.Net.WebSockets;

namespace GerenciamentoDePets.Repositories;

public class PetRepository : IPetRepository
{
    private readonly GerenciamentoDePetsContext _context;

    public PetRepository(GerenciamentoDePetsContext context)
    {
        _context = context;
    }
    public void AtualizarPet(Guid id, Pet pet)
    {
        var petExistente = _context.Pets.Find(id);

        if (petExistente != null)
        {
            petExistente.Nome = String.IsNullOrWhiteSpace(pet.Nome) ? petExistente.Nome : pet.Nome;
            petExistente.Peso = pet.Peso != 0 ? pet.Peso : petExistente.Peso;
            petExistente.Idade = String.IsNullOrWhiteSpace(pet.Idade) ? petExistente.Idade : pet.Idade;
            petExistente.Imagem = String.IsNullOrWhiteSpace(pet.Imagem) ? petExistente.Imagem : pet.Imagem;
            petExistente.IdResponsavel = pet.IdResponsavel ?? petExistente.IdResponsavel;
            _context.SaveChanges();
        }
    }


    public List<Pet> BuscarPorId(Guid id)
    {
        return _context.Pets.Where(p => p.IdPet == id).ToList();//ARRUMAR DEPOIS 
    }

    public void CadastrarPet(Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
    }

    public void DeletarPet(Guid IdPet)
    {
        var pet = _context.Pets.Find(IdPet);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }
    public List<Pet> ListarPets()
    {
        return _context.Pets.ToList();
    }
}
