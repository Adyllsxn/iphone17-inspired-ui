namespace Kairos.Domain.Abstrations.Interfaces;
public interface DashboardRepository
{
    Task<DashboardEntity> GetQtdItems(CancellationToken token);
}
