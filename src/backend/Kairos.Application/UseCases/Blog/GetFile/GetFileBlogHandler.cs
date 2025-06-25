namespace Kairos.Application.UseCases.Blog.GetFile;
public class GetFileBlogHandler(IBlogRepository repository)
{
    public async Task<QueryResult<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetFileBlogResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetFileAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetFileBlogResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetFileBlog();
            
            return new QueryResult<GetFileBlogResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetFileBlogResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}"
                );
        }
    }
}
