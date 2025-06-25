namespace Kairos.Application.UseCases.Perfil.GetById;
public class GetPerfilByIdHandler(IPerfilRepository repository)
{
    public async Task<QueryResult<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetPerfilByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetPerfilByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetPerfilById();
            
            return new QueryResult<GetPerfilByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetPerfilByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
