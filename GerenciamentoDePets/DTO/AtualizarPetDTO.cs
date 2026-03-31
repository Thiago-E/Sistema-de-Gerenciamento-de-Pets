using Microsoft.AspNetCore.Http;

public class AtualizarPetDTO
{
    public string Nome { get; set; } = null!;
    public string Idade { get; set; }
    public string Peso { get; set; } = null!;

    public Guid? IdResponsavel { get; set; }
    public Guid? IdTipoPet { get; set; }

    public IFormFile? Imagem { get; set; }
}