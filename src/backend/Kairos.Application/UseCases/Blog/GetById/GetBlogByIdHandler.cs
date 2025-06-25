namespace Kairos.Application.UseCases.Blog.GetById;
public class GetBlogByIdHandler (IBlogRepository repository)
{
    public async Task<QueryResult<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetBlogByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetBlogByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetBlogById();
            
            return new QueryResult<GetBlogByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetBlogByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
