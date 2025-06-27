namespace Kairos.Application.UseCases.Blog.Update;
public class UpdateBlogHandler(IBlogRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<UpdateBlogResponse>> UpdateHendler(UpdateBlogCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToBlogEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync(token);

            return new QueryResult<UpdateBlogResponse>(
                response.Data?.MapToUpdateBlog(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<UpdateBlogResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}
