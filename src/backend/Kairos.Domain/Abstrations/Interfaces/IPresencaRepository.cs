namespace Kairos.Domain.Abstrations.Interfaces;
public interface IPresencaRepository
{
    Task<QueryResult<PresencaEntity>> CreateAsync (PresencaEntity entity, CancellationToken token);
    Task<QueryResult<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<QueryResult<PresencaEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<PresencaEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<PresencaEntity>> UpdateAsync (PresencaEntity entity, CancellationToken token);
}
