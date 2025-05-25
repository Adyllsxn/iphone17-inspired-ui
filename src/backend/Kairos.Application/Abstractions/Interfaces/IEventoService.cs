namespace Kairos.Application.Abstractions.Interfaces;
public interface IEventoService
{
    Task<Result<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token);
    Task<Result<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token);
}
