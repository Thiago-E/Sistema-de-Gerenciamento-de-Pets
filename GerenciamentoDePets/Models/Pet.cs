using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePets.Models;

[Table("Pet")]
public partial class Pet
{
    [Key]
    public Guid IdPet { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    public double Peso { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string Idade { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid? IdResponsavel { get; set; }

    public Guid? IdTipoPet { get; set; }

    [ForeignKey("IdResponsavel")]
    [InverseProperty("Pets")]
    public virtual Responsavel? IdResponsavelNavigation { get; set; }

    [ForeignKey("IdTipoPet")]
    [InverseProperty("Pets")]
    public virtual TipoPet? IdTipoPetNavigation { get; set; }
}
