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

    // 🔍 Buscar por ID (CORRIGIDO - agora retorna 1 objeto)
    public Pet? BuscarPorId(Guid id)
    {
        return _context.Pets.FirstOrDefault(p => p.IdPet == id);
    }

    // 📋 Listar todos
    public List<Pet> ListarPets()
    {
        return _context.Pets.ToList();
    }

    // ➕ Cadastrar
    public void CadastrarPet(Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
    }

    // ✏️ Atualizar (CORRIGIDO)
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

    // ❌ Deletar
    public void DeletarPet(Guid id)
    {
        var pet = _context.Pets.Find(id);

        if (pet != null)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }

   

    public void AtualizarPet(Pet petExistente)
    {
        throw new NotImplementedException();
    }
}