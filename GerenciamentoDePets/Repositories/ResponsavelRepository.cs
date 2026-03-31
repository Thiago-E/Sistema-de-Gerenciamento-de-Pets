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
    /// Atualiza os dados de um responsável existente no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único do responsável.</param>
    /// <param name="responsavel">Objeto contendo os novos dados do responsável.</param>
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
    /// Cadastra um novo responsável no banco de dados.
    /// </summary>
    /// <param name="responsavel">Objeto do tipo Responsavel a ser cadastrado.</param>
    public void CadastrarResponsavel(Responsavel responsavel)
    {
        _context.Responsavels.Add(responsavel);
        _context.SaveChanges();
    }
    /// <summary>
    /// Lista todos os responsáveis cadastrados no banco de dados.
    /// </summary>
    /// <returns>Retorna a lista de responsaveis</returns>
    public List<Responsavel> Listar()
    {
        return _context.Responsavels.ToList();
    }
}
