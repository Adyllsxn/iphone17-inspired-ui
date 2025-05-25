namespace Kairos.Presentation.Features.Evento.Controller;
[ApiController]
[Route("api/")]
public class EventosController(IEventoService service) : ControllerBase
{
    #region </GetFile>
        [HttpGet("EventoImage"), EndpointSummary("Obter a imagem do Evento Pelo Id")]
        public async Task<ActionResult> GetFile([FromQuery] GetFileEventoCommand command, CancellationToken token)
        {
                var response = await service.GetFileHandler(command,token);
                if(response.Data?.ImagemUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.ImagemUrl);
                return File(databyte, "image/jpg");
        }
    #endregion

    #region </Create>
        [HttpPost("CreateEvento"), EndpointSummary("Criar Evento")]
        public async Task<ActionResult> Create([FromForm] CreateEventoModel model, CancellationToken token)
        {
            if (model.ImagemUrl == null || model.ImagemUrl.Length == 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            string pastaRaiz = "Storage";
            string pastaImagens = Path.Combine(pastaRaiz, "Images");
            if (!Directory.Exists(pastaImagens))
            {
                Directory.CreateDirectory(pastaImagens);
            }

            var extensao = Path.GetExtension(model.ImagemUrl.FileName).ToLower();
            var extensoesPermitidas = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif" };
            if (!extensoesPermitidas.Contains(extensao))
            {
                return BadRequest($"Extensão de arquivo não suportada: {extensao}. Permitidos: JPG, JPEG, PNG, GIF.");
            }

            string nomeArquivo = $"{Guid.NewGuid()}{extensao}";
            string caminhoCompleto = Path.Combine(pastaImagens, nomeArquivo);

            await using var stream = new FileStream(caminhoCompleto, FileMode.Create);
            await model.ImagemUrl.CopyToAsync(stream);

            var newCommand = new CreateEventoCommand{
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataHoraInicio = model.DataHoraInicio,
                DataHoraFim = model.DataHoraFim,
                Local = model.Local,
                TipoEventoID = model.TipoEventoID,
                UsuarioID = model.UsuarioID,
                ImagemUrl = caminhoCompleto
            };
            var response = await service.CreateHandler(newCommand,token);
            return Ok(response);
        }
    #endregion
}
