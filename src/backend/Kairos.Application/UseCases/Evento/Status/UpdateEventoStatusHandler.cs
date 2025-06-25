namespace Kairos.Application.UseCases.Evento.Status;
public class UpdateEventoStatusHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<UpdateEventoStatusResponse>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new QueryResult<UpdateEventoStatusResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.AtualizarStatus(command.StatusAprovacao);

            await unitOfWork.CommitAsync();

            var response = entity.MapToUpdateStatusResponse(); 

            return new QueryResult<UpdateEventoStatusResponse>(response, 200, "Status atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return new QueryResult<UpdateEventoStatusResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
