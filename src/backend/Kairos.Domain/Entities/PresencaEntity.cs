namespace Kairos.Domain.Entities;
public sealed class PresencaEntity : EntityBase, IAggragateRoot
{
    public int UsuarioID { get; private set; }
    public int EventoID { get; private set; }
    public bool Confirmado { get; private set; }
    public DateTime DataHoraCheckin { get; private set; } = DateTime.UtcNow;

    [JsonIgnore]
    public UsuarioEntity Usuario { get; private set; } = null!;
    
    [JsonIgnore]
    public EventoEntity Evento { get; private set; } = null!;

    [JsonConstructor]
    public PresencaEntity() {}

    public PresencaEntity(int usuarioID, int eventoID, bool confirmado)
    {
        ValidationDomain(usuarioID, eventoID);
        Confirmado = confirmado;
    }

    public PresencaEntity(int id, int usuarioID, int eventoID, bool confirmado)
    {
        DomainValidationException.When(id <= 0, "ID deve ser maior que zero.");
        Id = id;
        ValidationDomain(usuarioID, eventoID);
        Confirmado = confirmado;
    }

    private void ValidationDomain(int usuarioID, int eventoID)
    {
        DomainValidationException.When(usuarioID <= 0, "ID do Usuário deve ser maior que zero.");
        DomainValidationException.When(eventoID <= 0, "ID do Evento deve ser maior que zero.");

        UsuarioID = usuarioID;
        EventoID = eventoID;
    }
}
