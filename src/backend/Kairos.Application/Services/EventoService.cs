namespace Kairos.Application.Services;
public class EventoService(CreateEventoHandler create, DeleteEventoHandler delete,GetEventosHandler get ,GetFileEventoHandler getFile, GetEventoByIdHandler getById, GetEventosPendenteHandler pendente, GetEventosReijetadoHandler reijetado, GetEventosAprovadoHandler aprovado, SearchEventoHandler search, UpdateEventoHandler update, UpdateEventoStatusHandler updateStatus) : IEventoService
{   
    #region GetAll
        public async Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token)
        {
            return await get.GetHandler(command, token);
        }
    #endregion
    
    #region GetById
        public async Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token)
        {
            return await getById.GetByIdHandler(command, token);
        }
    #endregion
    
    #region GetFile
        public async Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
        {
            return await getFile.GetFileHandler(command, token);
        }
    #endregion
    
    #region GetPendente
        public async Task<PagedList<List<GetEventosResponse>?>> GePendentetHandler(GetEventosCommand command, CancellationToken token)
        {
            return await pendente.GePendentetHandler(command, token);
        }
    #endregion

    #region GetAprovado
        public async Task<PagedList<List<GetEventosResponse>?>> GetAprovadoHandler(GetEventosCommand command, CancellationToken token)
        {
            return await aprovado.GetAprovadoHandler(command, token);
        }
    #endregion

    #region GetReijetado
        public async Task<PagedList<List<GetEventosResponse>?>> GetReijetadoHandler(GetEventosCommand command, CancellationToken token)
        {
            return await reijetado.GetReijetadoHandler(command, token);
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion
    
    #region Create
        public async Task<CommandResult<bool>> CreateHandler(CreateEventoCommand command, CancellationToken token)
        {
            return await create.CreateHandler(command, token);
        }
    #endregion

    #region Update
        public async Task<CommandResult<bool>> UpdateHendler(UpdateEventoCommand command, CancellationToken token)
        {
            return await update.UpdateHendler(command, token);
        }
    #endregion
    
    #region Status
        public async Task<CommandResult<bool>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
        {
            return await updateStatus.StatusHandler(command, token);
        }
    #endregion

    #region Delete
        public async Task<CommandResult<bool>> DeleteHandler(DeleteEventoCommand command, CancellationToken token)
        {
            return await delete.DeleteHandler(command, token);
        }
    #endregion

}
