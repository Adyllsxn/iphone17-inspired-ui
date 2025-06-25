namespace Kairos.Application.Abstractions.Interfaces;
public interface IPresencaService
{
    Task<QueryResult<CreatePresencaResponse>> CreateHandler(CreatePresencaCommand command, CancellationToken token);
    Task<QueryResult<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token);
    Task<PagedList<List<GetPresencaResponse>?>> GetHandler(GetPresencaCommand command, CancellationToken token);
    Task<QueryResult<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token);
}
