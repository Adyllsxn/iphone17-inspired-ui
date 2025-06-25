namespace Kairos.Application.Services;
public class EventoService(CreateEventoHandler create, DeleteEventoHandler delete,GetEventosHandler get ,GetFileEventoHandler getFile, GetEventoByIdHandler getById, GetEventosPendenteHandler pendente, GetEventosReijetadoHandler reijetado, GetEventosAprovadoHandler aprovado, SearchEventoHandler search, UpdateEventoHandler update, UpdateEventoStatusHandler updateStatus) : IEventoService
{
    public async Task<QueryResult<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<QueryResult<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<PagedList<List<GetEventosResponse>?>> GePendentetHandler(GetEventosCommand command, CancellationToken token)
    {
        return await pendente.GePendentetHandler(command, token);
    }

    public async Task<PagedList<List<GetEventosResponse>?>> GetAprovadoHandler(GetEventosCommand command, CancellationToken token)
    {
        return await aprovado.GetAprovadoHandler(command, token);
    }

    public async Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
    {
        return await getFile.GetFileHandler(command, token);
    }

    public async Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<PagedList<List<GetEventosResponse>?>> GetReijetadoHandler(GetEventosCommand command, CancellationToken token)
    {
        return await reijetado.GetReijetadoHandler(command, token);
    }

    public async Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<QueryResult<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
    {
        return await updateStatus.StatusHandler(command, token);
    }

    public async Task<QueryResult<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token)
    {
        return await update.UpdateHendler(command, token);
    }
}
