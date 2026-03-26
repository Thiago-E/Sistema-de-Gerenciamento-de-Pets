using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePets.Models;

[Table("Responsavel")]
public partial class Responsavel
{
    [Key]
    public Guid IdResponsavel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("CPF")]
    [StringLength(11)]
    [Unicode(false)]
    public string Cpf { get; set; } = null!;

    [StringLength(255)]
    public string Telefone { get; set; } = null!;

    [InverseProperty("IdResponsavelNavigation")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
