namespace Kairos.Application.Abstractions.Interfaces;
public interface IEventoService
{
    Task<QueryResult<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token);
    Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token);
    Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetAprovadoHandler(GetEventosCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GePendentetHandler(GetEventosCommand command, CancellationToken token);
    Task<PagedList<List<GetEventosResponse>?>> GetReijetadoHandler(GetEventosCommand command, CancellationToken token);
    Task<QueryResult<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token);
    Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token);
    Task<QueryResult<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token);
    Task<QueryResult<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token);
}
