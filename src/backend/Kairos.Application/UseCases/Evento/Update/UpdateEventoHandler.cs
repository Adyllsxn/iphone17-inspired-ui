namespace Kairos.Application.UseCases.Evento.Update;
public class UpdateEventoHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<UpdateEventoResponse>> UpdateHendler(UpdateEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToEventoEntity();
            var response = await repository.UpdateAsync(entity, token);
            await unitOfWork.CommitAsync(token);

            return new QueryResult<UpdateEventoResponse>(
                response.Data?.MapToUpdateEvento(),
                response.Code,
                response.Message
            );
        }
        catch(Exception ex)
        {
            return new QueryResult<UpdateEventoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (UPDATE). Erro: {ex.Message}"
                );
        }
    }
}
