namespace Kairos.Tests.UnitTests.Repositories.Perfil;
public class SearchTests
{
    [Fact]
    public async Task SearchAsync_ShouldReturnNotFound_WhenNoMatch()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var result = await repository.SearchAsync(p => p.Nome == "Inexistente", "Teste", CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.Code);
    }
}
