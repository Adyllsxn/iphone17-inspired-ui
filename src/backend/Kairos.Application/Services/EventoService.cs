namespace Kairos.Application.Services;
public class EventoService(CreateEventoHandler create, GetFileEventoHandler getFile) : IEventoService
{
    public async Task<Result<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
    {
        return await getFile.GetFileHandler(command, token);
    }
}
