namespace Kairos.Application.Services;
public class UsuarioService( CreateUsuarioHandler create, DeleteUsuarioHandler delete, GetUsuariosHandler get, GetUsuarioByIdHandler getById, GetUsuarioFotoHandler getFoto, SearchUsuarioHandler search, ExistUsuarioHandler exist, UsuarioStatusHandler statusHandler, UpdateUsuarioHandler update, UpdateUsuarioFotoHandler updateFoto) : IUsuarioService
{
    public async Task<Result<CreateUsuarioResponse>> CreateHandler(CreateUsuarioCommand command, CancellationToken token)
    {
        return await create.CreateHandler(command, token);
    }

    public async Task<Result<bool>> DeleteHandler(DeleteUsuarioCommand command, CancellationToken token)
    {
        return await delete.DeleteHandler(command, token);
    }

    public async Task<Result<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
    {
        return await getById.GetByIdHandler(command, token);
    }

    public async Task<Result<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token)
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

    public async Task<Result<List<SearchUsuarioResponse>>> SearchHendler(SearchUsuarioCommand command, CancellationToken token)
    {
        return await search.SearchHendler(command, token);
    }

    public async Task<Result<UsuarioStatusResponse>> StatusHandler(UsuarioStatusCommand command, CancellationToken token)
    {
        return await statusHandler.StatusHandler(command, token);
    }

    public async Task<Result<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token)
    {
        return await updateFoto.UpdateFotoHandler(command, token);
    }

    public async Task<Result<UpdateUsuarioResponse>> UpdateHandler(UpdateUsuarioCommand command, CancellationToken token)
    {
        return await update.UpdateHandler(command, token);
    }
}