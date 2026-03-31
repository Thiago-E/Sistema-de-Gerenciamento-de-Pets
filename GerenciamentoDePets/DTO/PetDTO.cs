namespace GerenciamentoDePets.DTO;

public class PetDTO
{
    public string Nome { get; set; }

    public double Idade { get; set; }

    public string Peso { get; set; }

    public IFormFile? Imagem { get; set; }

    public Guid IdResponsavel { get; set; }

    public Guid IdTipoPet { get; set; }
}
