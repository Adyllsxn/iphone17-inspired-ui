namespace Kairos.Application.UseCases.Usuario.UpdateFoto;
public class UpdateUsuarioFotoCommand
{
    public int Id { get; set; }
    public string FotoUrl { get; set; } = null!;
}
