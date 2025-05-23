namespace Kairos.Tests.UnitTests.Repositories.Perfil;
public class UpdateTests
{
    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequest_WhenEntityIsNull()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var result = await repository.UpdateAsync(null!, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.Code);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);
        var fakePerfil = new PerfilEntity(999, "Novo Nome");

        var result = await repository.UpdateAsync(fakePerfil, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
    }
    
}
