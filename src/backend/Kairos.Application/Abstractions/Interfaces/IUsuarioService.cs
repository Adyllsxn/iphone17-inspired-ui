namespace Kairos.Application.Abstractions.Interfaces;
public interface IUsuarioService
{
    Task<QueryResult<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token);
    Task<QueryResult<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token);
    Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token);
    Task<QueryResult<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token);
    Task<QueryResult<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token);
    Task<bool> GetIfExistHandle();
    Task<QueryResult<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token);
    Task<QueryResult<UsuarioStatusResponse>> StatusHandler(UsuarioStatusCommand command, CancellationToken token);
    Task<QueryResult<UpdateUsuarioResponse>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token);
    Task<QueryResult<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token);
}
