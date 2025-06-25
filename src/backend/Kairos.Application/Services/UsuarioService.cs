namespace Kairos.Application.Services;
public class UsuarioService( CreateUsuarioHandler create, DeleteUsuarioHandler delete, GetUsuariosHandler get, GetUsuarioByIdHandler getById, GetUsuarioFotoHandler getFoto, SearchUsuarioHandler search, ExistUsuarioHandler exist, UsuarioStatusHandler statusHandler, UpdateUsuarioHandler update, UpdateUsuarioFotoHandler updateFoto) : IUsuarioService
{
    public async Task<QueryResult<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<QueryResult<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<QueryResult<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<QueryResult<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token)
    {
        return await getFoto.GetFotoHandler(command, token);
    }

    public async Task<PagedList<List<GetUsuariosResponse>?>> GetHandler(GetUsuariosCommand command, CancellationToken token)
    {
        return await get.GetHandler(command, token);
    }

    public async Task<bool> GetIfExistHandle()
    {
        return await exist.GetIfExistHandle();
    }

    public async Task<QueryResult<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<QueryResult<UsuarioStatusResponse>> StatusHandler(UsuarioStatusCommand command, CancellationToken token)
    {
        return await statusHandler.StatusHandler(command, token);
    }

    public async Task<QueryResult<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token)
    {
        return await updateFoto.UpdateFotoHandler(command, token);
    }

    public async Task<QueryResult<UpdateUsuarioResponse>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token)
    {
        return await update.UpdateHandler(command, token);
    }
}