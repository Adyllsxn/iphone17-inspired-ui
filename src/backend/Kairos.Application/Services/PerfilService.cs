namespace Kairos.Application.Services;
public class PerfilService(GetPerfilsHandler get, GetPerfilByIdHandler getById, SearchPerfilHandler search) : IPerfilService
{
    #region GetAll
        public async Task<QueryResult<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token)
        {
            return await getById.GetByIdHandler(command, token);
        }
    #endregion

    #region GetById
        public async Task<QueryResult<List<GetPerfilsResponse>>> GetHandler(CancellationToken token)
        {
            return await get.GetHandler(token);
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token)
        {
            return await search.SearchHendler(command, token);
        }
    #endregion
}
