namespace Kairos.Infrastructure.Context.Connections;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}