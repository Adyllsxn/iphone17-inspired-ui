namespace Kairos.Application.Abstractions.Interfaces;
public interface IPerfilService
{
    Task<QueryResult<List<GetPerfilsResponse>>> GetHandler(CancellationToken token);
    Task<QueryResult<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token);
    Task<QueryResult<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token);
}
