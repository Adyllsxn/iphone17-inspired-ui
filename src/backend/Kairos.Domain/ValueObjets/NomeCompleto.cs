namespace Kairos.Domain.ValueObjets;
public class NomeCompleto
{
    public string? Nome { get; set; }
    public string? SobreNome { get; set; }

    public NomeCompleto(string nome, string sobreNome)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório.");
        DomainValidationException.When(nome.Length > 50, "Nome deve ter no máximo 50 caracteres.");

        DomainValidationException.When(string.IsNullOrWhiteSpace(sobreNome), "SobreNome é obrigatório.");
        DomainValidationException.When(sobreNome.Length > 50, "SobreNome deve ter no máximo 50 caracteres.");

        Nome = nome;
        SobreNome = sobreNome;
    }
}
