using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Interfaces;

public interface IPetRepository
{
    void CadastrarPet(Pet pet);

    List<Pet> ListarPets();

    // 🔥 CORRIGIDO: retorna um único objeto
    Pet? BuscarPorId(Guid id);

    // 🔥 CORRIGIDO: sem DTO aqui (controller que trata isso)
    void AtualizarPet(Guid id, Pet pet);

    void DeletarPet(Guid id);
}