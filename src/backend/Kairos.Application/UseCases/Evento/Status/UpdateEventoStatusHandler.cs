namespace Kairos.Application.UseCases.Evento.Status;
public class UpdateEventoStatusHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> StatusHandler(UpdateEventoStatusCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);
            if (resultEntity == null || resultEntity.Data == null)
            {
                return CommandResult<bool>.Failure(
                value: false,
                message: $"Evento {command.Id} não encontrado.",
                code: StatusCode.NoContent
                );
            }

            var entity = resultEntity.Data;
            entity.AtualizarStatus(command.StatusAprovacao);

            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: "Status atualizado com sucesso.",
                code: StatusCode.NoContent
                );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (STATUS). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
