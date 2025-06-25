namespace Kairos.Application.UseCases.Usuario.Status;
public class UsuarioStatusHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<QueryResult<UsuarioStatusResponse>> StatusHandler(UsuarioStatusCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new QueryResult<UsuarioStatusResponse>(null, 404, "Evento não encontrado.");

            var entity = resultEntity.Data;

            entity.UpdatePerfil(command.Perfil.Id);

            await unitOfWork.CommitAsync();

            var response = entity.MapToUsuarioStatusResponse(); 

            return new QueryResult<UsuarioStatusResponse>(response, 200, "Status atualizado com sucesso.");
        }
        catch (DomainValidationException ex)
        {
            // captura erro de domínio e devolve como resultado
            return new QueryResult<UsuarioStatusResponse>(null, 400, ex.Message);
        }
        catch (Exception ex)
        {
            return new QueryResult<UsuarioStatusResponse>(null, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }

}
