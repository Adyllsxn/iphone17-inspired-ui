namespace Kairos.Application.Abstractions.Interfaces;
public interface ITipoEventoService
{
    Task<PagedList<List<GetTipoEventosResponse>?>> GetHandler(GetTipoEventosCommand command, CancellationToken token);
    Task<QueryResult<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token);
    Task<QueryResult<List<SearchTipoEventoResponse>>> SearchHendler(SearchTipoEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> UpdateHendler(UpdateTipoEventoCommand command, CancellationToken token);
    Task<CommandResult<bool>> DeleteHandler(DeleteTipoEventoCommand command, CancellationToken token);

}
