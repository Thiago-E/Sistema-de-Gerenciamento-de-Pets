using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Interfaces;

public interface IPetRepository
{
    void CadastrarPet(Pet pet);

}
