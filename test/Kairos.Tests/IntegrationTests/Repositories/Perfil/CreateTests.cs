namespace Kairos.Tests.UnitTests.Repositories.Perfil;
public class CreateTests 
{
    [Fact]
    public async Task CreateAsync_ShouldReturnBadRequest_WhenEntityIsNull()
    {
        // Arrange
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        // Act
        var result = await repository.CreateAsync(null!, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.Code);
        Assert.Equal("Parâmetros não podem estar vazio.", result.Message);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreated_WhenEntityIsValid()
    {
        using var context = InMemoryDB.CreateInMemoryDbContext();
        var repository = new PerfilRepository(context);

        var perfilValido = new PerfilEntity("Perfil Teste");

        var result = await repository.CreateAsync(perfilValido, CancellationToken.None);

        // Aqui, força o save no teste, porque o repo não chama SaveChangesAsync
        await context.SaveChangesAsync(CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal(201, result.Code);
        Assert.Equal("Operação executada com sucesso.", result.Message);
        Assert.NotNull(result.Data);
        Assert.Equal("Perfil Teste", result.Data!.Nome);
    }
}
