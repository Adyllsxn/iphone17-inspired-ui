namespace Kairos.Application.UseCases.Blog.Publish;
public class PublishBlogCommand
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public int Id { get; set; }

    [JsonIgnore]
    [Required(ErrorMessage = "Status de Postagem é obrigatório")]
    public EBlog StatusPostagem { get; set; } = EBlog.Publicado;
}
