namespace Kairos.Application.UseCases.TipoEvento.Create;
public class CreateTipoEventoHandler(ITipoEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<CreateTipoEventoResponse>> CreateHandler(CreateTipoEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToTipoEventoEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync();

            return new QueryResult<CreateTipoEventoResponse>(
                response.Data?.MapToCreateTipoEvento(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<CreateTipoEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
