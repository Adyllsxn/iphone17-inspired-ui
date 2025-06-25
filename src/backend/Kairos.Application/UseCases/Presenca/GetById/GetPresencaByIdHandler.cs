namespace Kairos.Application.UseCases.Presenca.GetById;
public class GetPresencaByIdHandler(IPresencaRepository repository)
{
    public async Task<QueryResult<GetPresencaByIdResponse>> GetByIdHandler(GetPresencaByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetPresencaByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetPresencaByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetPresencaById();
            
            return new QueryResult<GetPresencaByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetPresencaByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
