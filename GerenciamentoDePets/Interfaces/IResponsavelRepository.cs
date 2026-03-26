using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Interfaces;

public interface IResponsavelRepository
{
    void CadastrarResponsavel(Responsavel responsavel);
    List<Responsavel> Listar();
    void AtualizarResponsavel(Guid id, Responsavel responsavel);
}
