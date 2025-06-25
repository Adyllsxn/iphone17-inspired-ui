namespace Kairos.Application.UseCases.Evento.GetFile;
public class GetFileEventoHandler(IEventoRepository repository)
{
    public async Task<QueryResult<GetFileEventoResponse>> GetFileHandler(GetFileEventoCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new QueryResult<GetFileEventoResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetFileAsync(command.Id, token);
            if (response.Data == null)
            {
                return new QueryResult<GetFileEventoResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetFileEvento();
            
            return new QueryResult<GetFileEventoResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new QueryResult<GetFileEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}"
                );
        }
    }
}