namespace Kairos.Application.Abstractions.Interfaces;
public interface IBlogService
{
    Task<QueryResult<ArchiveBlogResponse>> ArchiveHandler(ArchiveBlogCommand command, CancellationToken token);
    Task<QueryResult<CreateBlogResponse>> CreateHandler(CreateBlogCommand command, CancellationToken token);
    Task<QueryResult<bool>> DeleteHandler(DeleteBlogCommand command, CancellationToken token);
    Task<PagedList<List<GetBlogsResponse>?>> GetHandler(GetBlogsCommand command, CancellationToken token);
    Task<QueryResult<GetBlogByIdResponse>> GetByIdHandler(GetBlogByIdCommand command, CancellationToken token);
    Task<QueryResult<GetFileBlogResponse>> GetFileHandler(GetFileBlogCommand command, CancellationToken token);
    Task<PagedList<List<GetBlogsResponse>?>> GetPublishHandler(GetPublishBlogCommand command, CancellationToken token);
    Task<QueryResult<PublishBlogResponse>> PublishHandler(PublishBlogCommand command, CancellationToken token);
    Task<QueryResult<List<GetBlogsResponse>>> SearchHendler(SearchBlogCommand command, CancellationToken token);
    Task<QueryResult<UpdateBlogResponse>> UpdateHendler(UpdateBlogCommand command, CancellationToken token);
}
