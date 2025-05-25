namespace Kairos.Application.Abstractions.ExtensionsMethods.Evento;
public static class GetFileEventoExtensions
{
    public static GetFileEventoResponse MapToGetFileEvento (this EventoEntity entity)
    {
        return new GetFileEventoResponse
        {
            ImagemUrl = entity.ImagemUrl
        };
    }
    public static IEnumerable<GetFileEventoResponse> MapToGetFileEvento(this IEnumerable<EventoEntity> response)
    {
        return response.Select(entity => entity.MapToGetFileEvento());
    }
}
