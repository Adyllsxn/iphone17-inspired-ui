namespace Kairos.Domain.Abstrations.Interfaces;
public interface IEventoRepository
{
    Task<PagedList<List<EventoEntity>?>> GetAllAsync (PagedRequest request, CancellationToken token);
    Task<QueryResult<EventoEntity?>> GetByIdAsync (int entityId, CancellationToken token);
    Task<QueryResult<EventoEntity?>> GetFileAsync (int entityId, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosAprovadosAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosRejeitadosAsync(PagedRequest request, CancellationToken token);
    Task<PagedList<List<EventoEntity>?>> GetEventosPendentesAsync(PagedRequest request, CancellationToken token);
    Task<QueryResult<List<EventoEntity>?>> SearchAsync (Expression<Func<EventoEntity, bool>> expression, string entity, CancellationToken token);
    Task<CommandResult<bool>> CreateAsync (EventoEntity entity, CancellationToken token);
    Task<CommandResult<bool>> UpdateAsync (EventoEntity entity, CancellationToken token);
    Task<CommandResult<bool>> DeleteAsync (int entityId, CancellationToken token);

}
