namespace Kairos.Application.UseCases.Evento.GetFile;
public class GetFileEventoCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }
}
