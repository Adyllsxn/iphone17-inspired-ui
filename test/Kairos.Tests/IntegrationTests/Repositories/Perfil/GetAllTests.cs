namespace Kairos.Tests.UnitTests.Repositories.Perfil;
public class GetAllTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnNotFound_WhenNoDataExists()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var result = await repository.GetAllAsync(CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
    }
    
}
