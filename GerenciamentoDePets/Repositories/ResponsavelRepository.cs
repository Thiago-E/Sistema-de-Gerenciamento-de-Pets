using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Repositories;

public class ResponsavelRepository : IResponsavelRepository
{
    private readonly GerenciamentoDePetsContext _context;

    public ResponsavelRepository(GerenciamentoDePetsContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que atualiza o responsavel pelo id
    /// </summary>
    /// <param name="id">Id do responsavel a ser atualizado</param>
    /// <param name="responsavel">Nome do responsavel a ser atualizado</param>
    public void AtualizarResponsavel(Guid id, Responsavel responsavel)
    {
        var responsavelExistente = _context.Responsavels.Find(id);

        if (responsavelExistente != null)
        {
            responsavelExistente.Nome = responsavel.Nome;
            responsavelExistente.Cpf = responsavel.Cpf;
            responsavelExistente.Telefone = responsavel.Telefone;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que cadastra um novo responsavel
    /// </summary>
    /// <param name="responsavel">Nome do responsavel a ser cadastrado</param>
    public void CadastrarResponsavel(Responsavel responsavel)
    {
        _context.Responsavels.Add(responsavel);
        _context.SaveChanges();
    }

    /// <summary>
    /// Metodo que lista os responsaveis
    /// </summary>
    /// <returns></returns>
    public List<Responsavel> Listar()
    {
        return _context.Responsavels.ToList();
    }
}
