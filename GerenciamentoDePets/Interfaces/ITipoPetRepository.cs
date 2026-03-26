using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Interfaces;

public interface ITipoPetRepository
{
    void CadastrarTipoPet(TipoPet tipoPet);
    List<TipoPet> Listar();
    void AtualizarTipoPet(Guid id, TipoPet tipoPet);
}
