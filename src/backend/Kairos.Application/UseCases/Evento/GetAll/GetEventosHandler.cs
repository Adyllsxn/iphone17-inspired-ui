namespace Kairos.Application.UseCases.Evento.GetAll;
public class GetEventosHandler(IEventoRepository repository)
{
    public async Task<PagedList<List<GetEventosResponse>?>> GetHandler(GetEventosCommand command, CancellationToken token)
    {
        try
        {
            var response = await repository.GetAllAsync(command,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new PagedList<List<GetEventosResponse>?>(
                    data: null,
                    message: "Nenhum dado encontrado",
                    code: StatusCode.NotFound
                    );
            }
            var result = response.Data.MapToGetEventos().ToList();
            
            return new PagedList<List<GetEventosResponse>?>(
                data: result, 
                message: "Dados encontrados",
                code: StatusCode.OK
                );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetEventosResponse>?>(
                data: null, 
                message: $"Erro ao manupular a operação (GET ALL). Erro: {ex.Message}",
                code: StatusCode.InternalServerError
                );
        }
    }
}
