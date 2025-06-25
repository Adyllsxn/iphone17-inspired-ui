namespace Kairos.Domain.Abstrations.Interfaces;
public interface IBlogRepository
{
    Task<QueryResult<BlogEntity>> CreateAsync (BlogEntity entity, CancellationToken token);
    Task<QueryResult<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<QueryResult<BlogEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<QueryResult<BlogEntity?>> GetFileAsync (int entityId, CancellationToken token);
    Task<PagedList<List<BlogEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<PagedList<List<BlogEntity>?>> GetAllPublishAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<BlogEntity>> UpdateAsync (BlogEntity entity, CancellationToken token);
    Task<QueryResult<List<BlogEntity>?>> SearchAsync (Expression<Func<BlogEntity, bool>> expression, string entity, CancellationToken token);
}
