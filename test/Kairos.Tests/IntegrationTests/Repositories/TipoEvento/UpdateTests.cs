namespace Kairos.Tests.UnitTests.Repositories.TipoEvento;
public class UpdateTests
{
    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequest_WhenEntityIsNull()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new TipoEventoRepository(context);

        var result = await repository.UpdateAsync(null!, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.Code);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new TipoEventoRepository(context);
        var fakePerfil = new TipoEventoEntity(999, "Novo Nome");

        var result = await repository.UpdateAsync(fakePerfil, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
    }
    
}
