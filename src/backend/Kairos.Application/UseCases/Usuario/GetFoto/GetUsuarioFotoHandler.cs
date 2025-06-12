namespace Kairos.Application.UseCases.Usuario.GetFoto;
public class GetUsuarioFotoHandler(IUsuarioRepository repository)
{
    public async Task<Result<GetUsuarioFotoResponse>> GetFotoHandler(GetUsuarioFotoCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetUsuarioFotoResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetFotoAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetUsuarioFotoResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetUsuarioFoto();
            
            return new Result<GetUsuarioFotoResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetUsuarioFotoResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET FILE). Erro: {ex.Message}"
                );
        }
    }
}
