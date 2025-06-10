namespace Kairos.Application.Abstractions.ExtensionsMethods.Dashboard;
public static class GetDashboardExtensions
{
    public static GetDashboardResponse MapToGetDashboard (this DashboardEntity entity)
    {
        return new GetDashboardResponse
        {
            QtdTipoEvento = entity.QtdTipoEvento,
            QtdEvento = entity.QtdEvento,
            QtdUsuario = entity.QtdUsuario,
            QtdPerfil = entity.QtdPerfil,
            QtdPresenca = entity.QtdPresenca,
            QtdBlog = entity.QtdBlog
        };
    }
    public static IEnumerable<GetDashboardResponse> MapToGetDashboard(this IEnumerable<DashboardEntity> response)
    {
        return response.Select(entity => entity.MapToGetDashboard());
    }
}