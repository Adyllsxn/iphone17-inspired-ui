namespace Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
public static class GetUsuarioFotoExtensions
{
    public static GetUsuarioFotoResponse MapToGetUsuarioFoto (this UsuarioEntity entity)
    {
        return new GetUsuarioFotoResponse
        {
            FotoUrl = entity.FotoUrl
        };
    }
    public static IEnumerable<GetUsuarioFotoResponse> MapToGetUsuarioFoto(this IEnumerable<UsuarioEntity> response)
    {
        return response.Select(entity => entity.MapToGetUsuarioFoto());
    }
}
