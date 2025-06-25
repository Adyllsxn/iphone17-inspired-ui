namespace Kairos.Application.Services;
public class PerfilService(GetPerfilsHandler get, GetPerfilByIdHandler getById, SearchPerfilHandler search) : IPerfilService
{
    public async Task<QueryResult<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<QueryResult<List<GetPerfilsResponse>>> GetHandler(CancellationToken token)
    {
        return await get.GetHandler(token);
    }

    public async Task<QueryResult<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }
}
