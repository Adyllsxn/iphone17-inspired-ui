namespace Kairos.Domain.Abstrations.Interfaces;
public interface IUsuarioRepository
{
    Task<QueryResult<UsuarioEntity>> CreateAsync (UsuarioEntity entity, CancellationToken token);
    Task<QueryResult<bool>> DeleteAsync (int entityId, CancellationToken token);
    Task<bool> GetIfExistAsync();
    Task<QueryResult<UsuarioEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<PagedList<List<UsuarioEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<UsuarioEntity?>> GetFotoAsync (int entityId, CancellationToken token);
    Task<bool> GetIfUserExistAsync();
    Task<QueryResult<UsuarioEntity>> UpdateAsync (UsuarioEntity entity, CancellationToken token);
    Task<QueryResult<List<UsuarioEntity>?>> SearchAsync (Expression<Func<UsuarioEntity, bool>> expression, string entity, CancellationToken token);
}
