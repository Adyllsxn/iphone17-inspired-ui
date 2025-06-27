namespace Kairos.Domain.Abstrations.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token);
}
