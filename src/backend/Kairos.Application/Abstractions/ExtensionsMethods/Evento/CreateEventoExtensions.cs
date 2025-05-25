namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class CreateEventoExtensions
{
    public static EventoEntity MapToEventoEntity(this CreateEventoCommand command)
    {

        return new EventoEntity
        (
            command.Titulo,
            command.Descricao,
            command.DataHoraInicio,
            command.DataHoraFim,
            command.Local,
            command.TipoEventoID,
            command.UsuarioID,
            command.ImagemUrl
        );
    }
    
    public static CreateEventoResponse MapToCreateEvento (this EventoEntity entity)
    {
        return new CreateEventoResponse
        {
            Id = entity.Id,
            Titulo = entity.Titulo,
            Descricao = entity.Descricao,
            DataHoraInicio = entity.DataHoraInicio,
            DataHoraFim = entity.DataHoraFim,
            Local = entity.Local,
            TipoEventoID = entity.TipoEventoID,
            UsuarioID = entity.UsuarioID,
            ImagemUrl = entity.ImagemUrl
        };
    }
    public static IEnumerable<CreateEventoResponse> MapToCreateEvento(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToCreateEvento());
    }
}
