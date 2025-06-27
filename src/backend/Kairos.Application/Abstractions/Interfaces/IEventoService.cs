namespace Kairos.Application.Abstractions.Interfaces;
public interface IEventoService
{
    Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token);
    Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token);
    Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetAprovadoHandler(GetEventosCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GePendentetHandler(GetEventosCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetReijetadoHandler(GetEventosCommand command, CancellationToken token);
    Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> CreateHandler(CreateEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> UpdateHendler(UpdateEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token);
    Task<CommandResult<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token);
}
