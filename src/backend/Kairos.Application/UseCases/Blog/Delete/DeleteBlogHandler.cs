namespace Kairos.Application.UseCases.Blog.Delete;
public class DeleteBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<bool>> DeleteHandler(DeleteBlogCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.DeleteAsync(command.Id, token);
            await unitOfWork.CommitAsync(token);
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
