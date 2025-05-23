namespace Kairos.Tests.UnitTests.Repositories.TipoEvento;
public class GetByIdTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturnBadRequest_WhenIdIsInvalid()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new TipoEventoRepository(context);

        var result = await repository.GetByIdAsync(0, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.Code);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new TipoEventoRepository(context);

        var result = await repository.GetByIdAsync(999, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
    }

}
