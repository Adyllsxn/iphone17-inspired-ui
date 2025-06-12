namespace Kairos.Application.UseCases.Usuario.GetFoto;
public class GetUsuarioFotoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
