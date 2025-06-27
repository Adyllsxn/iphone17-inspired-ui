namespace Kairos.Application.Services;
public class TipoEventoService(CreateTipoEventoHandler create,DeleteTipoEventoHandler delete, GetTipoEventosHandler get, GetTipoEventoByIdHandler getById, SearchTipoEventoHandler search, UpdateTipoEventoHandler update) : ITipoEventoService
{
    #region GetAll
        public async Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token)
        {
            return await get.GetHandler(command, token);
        }
    #endregion
    
    #region GetById
        public async Task<QueryResult<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token)
        {
            return await getById.GetByIdHandler(command, token);
        }
    #endregion
    
    #region Search
        public async Task<QueryResult<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion
    
    #region Create
        public async Task<CommandResult<bool>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
        {
            return await create.CreateHandler(command, token);
        }
    #endregion
    
    #region Update
        public async Task<CommandResult<bool>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token)
        {
            return await update.UpdateHendler(command, token);
        }
    #endregion
    
    #region Delete
        public async Task<CommandResult<bool>> DeleteHandler(DeleteTipoEventoCommand command, CancellationToken token)
        {
            return await delete.DeleteHandler(command, token);
        }
    #endregion
}
