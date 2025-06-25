namespace Kairos.Application.UseCases.Presenca.Delete;
public class DeletePresencaHandler(IPresencaRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<bool>> DeleteHandler(DeletePresencaCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.DeleteAsync(command.Id, token);
            await unitOfWork.CommitAsync();
            return new QueryResult<bool>(
                response.Data,
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<bool>(
                false,
                500,
                $"Erro ao manipular a operação (DELETAR). Erro: {ex.Message}"
            );
        }
    }
}
