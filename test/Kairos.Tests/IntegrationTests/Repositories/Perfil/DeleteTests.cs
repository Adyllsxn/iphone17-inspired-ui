namespace Kairos.Tests.UnitTests.Repositories.Perfil;
public class DeleteTests
{
    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequest_WhenIdIsInvalid()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var result = await repository.DeleteAsync(0, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.Code);
        Assert.Equal("ID deve ser maior que zero.", result.Message);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var result = await repository.DeleteAsync(999, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
        Assert.Equal("ID não encontrado.", result.Message);
    }


}
