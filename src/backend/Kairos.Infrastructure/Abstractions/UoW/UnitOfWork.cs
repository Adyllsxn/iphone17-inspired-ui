namespace Kairos.Infrastructure.Abstractions.UoW;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken token)
    {
        await context.SaveChangesAsync();
    }
}