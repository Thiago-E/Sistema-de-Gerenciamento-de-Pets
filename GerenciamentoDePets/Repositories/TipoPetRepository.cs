using GerenciamentoDePets.BdContextGerenciamentoDePetsContext;
using GerenciamentoDePets.Interfaces;
using GerenciamentoDePets.Models;

namespace GerenciamentoDePets.Repositories;

public class TipoPetRepository : ITipoPetRepository
{
    private readonly GerenciamentoDePetsContext _context;

    public TipoPetRepository(GerenciamentoDePetsContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que atualiza o tipo do Pet
    /// </summary>
    /// <param name="id">Id do tipo pet a ser atualizado</param>
    /// <param name="tipoPet">Nome do tipo pet a ser atualizado</param>
    public void AtualizarTipoPet(Guid id, TipoPet tipoPet)
    {
        var tipoPetBuscado = _context.TipoPets.Find(tipoPet.IdTipoPet);
        if (tipoPetBuscado != null)
        {
            tipoPetBuscado.Especie = tipoPet.Especie;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que cadastra um novo tipo de pet
    /// </summary>
    /// <param name="tipoPet">Nome do novo tipo pet cadastrado</param>
    public void CadastrarTipoPet(TipoPet tipoPet)
    {
        _context.TipoPets.Add(tipoPet);
        _context.SaveChanges();
    }

    /// <summary>
    /// Metodo que mostra todos os tipos de pet listados
    /// </summary>
    /// <returns>Lista com todos os tipos de pet</returns>
    public List<TipoPet> Listar()
    {
        return _context.TipoPets
            .OrderBy(t => t.Especie)
            .ToList();
    }
}
