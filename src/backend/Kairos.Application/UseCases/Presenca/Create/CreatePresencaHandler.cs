namespace Kairos.Application.UseCases.Presenca.Create;
public class CreatePresencaHandler(IPresencaRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<CreatePresencaResponse>> CreateHandler(CreatePresencaCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToPresencaEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync(token);

            return new QueryResult<CreatePresencaResponse>(
                response.Data?.MapToCreatePresenca(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<CreatePresencaResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
