namespace Kairos.Application.UseCases.Evento.GetById;
public class GetEventoByIdHandler(IEventoRepository repository)
{
    public async Task<QueryResult<GetEventoByIdResponse>> GetByIdHandler(GetEventoByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetEventoByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetEventoByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetEventoById();
            
            return new QueryResult<GetEventoByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetEventoByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}   