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

    public void CadastrarResponsavel(Responsavel responsavel)
    {
        _context.Responsavels.Add(responsavel);
        _context.SaveChanges();
    }

    public List<Responsavel> Listar()
    {
        return _context.Responsavels.ToList();
    }
}
