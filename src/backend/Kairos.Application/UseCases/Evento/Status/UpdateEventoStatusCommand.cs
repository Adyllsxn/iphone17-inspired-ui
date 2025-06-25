namespace Kairos.Application.UseCases.Evento.Status;
public record UpdateEventoStatusCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Status de Aprovação é obrigatório")]
    public EAprovacao StatusAprovacao { get; set; }
}

