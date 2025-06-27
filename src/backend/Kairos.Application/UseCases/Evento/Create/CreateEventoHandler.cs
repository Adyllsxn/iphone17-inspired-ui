namespace Kairos.Application.UseCases.Evento.Create;
public class CreateEventoHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<CreateEventoResponse>> CreateHandler(CreateEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToEventoEntity();
            var response = await repository.CreateAsync(entity, token);
            await unitOfWork.CommitAsync(token);

            return new QueryResult<CreateEventoResponse>(
                response.Data?.MapToCreateEvento(), 
                response.Code, 
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<CreateEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (CRIAR). Erro: {ex.Message}"
                );
        }
    }
}
