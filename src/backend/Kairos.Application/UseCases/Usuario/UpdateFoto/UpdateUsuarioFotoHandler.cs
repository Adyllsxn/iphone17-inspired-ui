namespace Kairos.Application.UseCases.Usuario.UpdateFoto;
public class UpdateUsuarioFotoHandler(IUsuarioRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Result<bool>> UpdateFotoHandler(UpdateUsuarioFotoCommand command, CancellationToken token)
    {
        try
        {
            var resultEntity = await repository.GetByIdAsync(command.Id, token);

            if (resultEntity == null || resultEntity.Data == null)
                return new Result<bool>(false, 404, "Usuario não encontrado.");

            var entity = resultEntity.Data;

            entity.UpdateFoto(command.Id,command.FotoUrl);

            await unitOfWork.CommitAsync();

            return new Result<bool>(true, 200, "Foto atualizado com sucesso.");
        }
        catch (DomainValidationException ex)
        {
            return new Result<bool>(false, 400, ex.Message);
        }
        catch (Exception ex)
        {
            return new Result<bool>(false, 500, $"Erro ao atualizar status: {ex.Message}");
        }
    }
}
