namespace Kairos.Application.UseCases.Evento.Create;
public class CreateEventoHandler(IEventoRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<CommandResult<bool>> CreateHandler(CreateEventoCommand command, CancellationToken token)
    {
        try
        {
            var entity = command.MapToEventoEntity();
            var response = await repository.CreateAsync(entity, token);
            
            await unitOfWork.CommitAsync(token);
            return CommandResult<bool>.Success(
                value: true,
                message: response.Message,
                code: response.Code
                );
        }
        catch(Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"Erro ao manipular a operação (CRIAR). Erro {ex.Message}.",
                code: StatusCode.InternalServerError
                );
        }
    }
}
