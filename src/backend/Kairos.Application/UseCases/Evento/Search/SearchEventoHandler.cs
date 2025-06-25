namespace Kairos.Application.UseCases.Evento.Search;
public class SearchEventoHandler(IEventoRepository repository)
{
    public async Task<QueryResult<List<SearchEventoResponse>>> SearchHendler(SearchEventoCommand command, CancellationToken token)
    {
        try
        {
            if(command.Titulo == null)
            {
                return new QueryResult<List<SearchEventoResponse>>(
                    null, 
                    400, 
                    "Parâmetro não deve estar vazio."
                    );
            }
            var response = await repository.SearchAsync(x => x.Titulo.Contains(command.Titulo),string.Empty,token);

            if (response.Data == null || !response.Data.Any())
            {
                return new QueryResult<List<SearchEventoResponse>>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToSearchEvento().ToList();
            
            return new QueryResult<List<SearchEventoResponse>>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch (Exception ex)
        {
            return new QueryResult<List<SearchEventoResponse>>(
                null, 
                500, 
                $"Erro ao manipular a operação (SEARCH). Erro: {ex.Message}"
                );
        }
    }
}
