using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePets.Models;

[Table("TipoPet")]
public partial class TipoPet
{
    [Key]
    public Guid IdTipoPet { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Especie { get; set; } = null!;

    [InverseProperty("IdTipoPetNavigation")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
