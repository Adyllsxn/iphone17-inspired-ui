namespace Kairos.Presentation.Features.Usuario.Model;
public class UpdateUsuarioFotoModel
{
    public int Id { get; set; }
    public IFormFile FotoUrl { get; set; } = null!;
}
