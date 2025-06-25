namespace Kairos.Infrastructure.Repositories;
public class PresencaRepository(AppDbContext context) : IPresencaRepository
{
    #region Create
        public async Task<QueryResult<PresencaEntity>> CreateAsync(PresencaEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<PresencaEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                await context.Presencas.AddAsync(entity, token);
                return new QueryResult<PresencaEntity>(
                    entity, 
                    201, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PresencaEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (CRIAR). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Delete
        public async Task<QueryResult<bool>> DeleteAsync(int entityId, CancellationToken token)
        {
            try
            {
                if (entityId <= 0)
                {
                    return new QueryResult<bool>(
                        false, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Presencas.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return new QueryResult<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Presencas.Remove(response);
                return new QueryResult<bool>(
                    true, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<bool>(
                    false, 
                    500, 
                    $"Erro ao executar a operação (DELETAR). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetAll
        public async Task<PagedList<List<PresencaEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Presencas.AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<PresencaEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<PresencaEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<PresencaEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<PresencaEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Presencas.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<PresencaEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<PresencaEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PresencaEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Update
        public async Task<QueryResult<PresencaEntity>> UpdateAsync(PresencaEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<PresencaEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Presencas.FindAsync(entity.Id);
                if(response == null)
                {
                    return new QueryResult<PresencaEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new QueryResult<PresencaEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PresencaEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion
}
