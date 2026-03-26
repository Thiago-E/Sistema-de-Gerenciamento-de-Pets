using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Interfaces;

public interface IPetRepository
{
    void CadastrarPet(Pet pet);
    List<Pet> ListarPets();
    List<Pet> BuscarPorId(Guid id);
    void AtualizarPet(Guid id, Pet pet);
    void DeletarPet(Guid IdPet);


}
