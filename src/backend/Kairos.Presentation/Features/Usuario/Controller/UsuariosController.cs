using Kairos.Application.UseCases.Usuario.GetFoto;
using Kairos.Application.UseCases.Usuario.Status;
using Kairos.Application.UseCases.Usuario.Update;
using Kairos.Application.UseCases.Usuario.UpdateFoto;
using Kairos.Presentation.Features.Usuario.Model;

namespace Kairos.Presentation.Features.Usuario.Controller;
[ApiController]
[Route("v1/")]
public class UsuariosController(IUsuarioService service)  : ControllerBase
{

    #region </GetAll>
        [HttpGet("Usuarios"), EndpointSummary("Obter Usuarios")]
        [Authorize]
        public async Task<ActionResult> Get([FromQuery] GetUsuariosCommand command,CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema");
            }

            var response = await service.GetHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </GetById>
        [HttpGet("UsuarioById"), EndpointSummary("Obter Usuario Pelo Id")]
        [Authorize]
        public async Task<ActionResult> GetById([FromQuery] GetUsuarioByIdCommand command, CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(command.Id == 0)
            {
                command.Id = userId;
            }
            bool isAdmin = user.Data?.PerfilID == 1;
            bool consultandoProprioUsuario = user.Data?.Id == command.Id;

            if (!consultandoProprioUsuario && !isAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }
            var response = await service.GetByIdHandler(command,token);
            return Ok(response);
        }
    #endregion
    
    #region </GetNotId>
        [HttpGet("UsuarioGetNotId"), EndpointSummary("Obter Usuario Sem o  Id")]
        [Authorize]
        public async Task<ActionResult> GetGetNotId()
        {
            var command = new GetUsuarioByIdCommand();
            var token = new CancellationToken();
            
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand{Id = userId}, token);
            if(command?.Id == 0)
            {
                command.Id = userId;
            }
            bool isAdmin = user.Data?.PerfilID == 1;
            bool consultandoProprioUsuario = user.Data?.Id == command?.Id;

            if (!consultandoProprioUsuario && !isAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var newCommand = new GetUsuarioByIdCommand{
                Id = userId
            };
            var response = await service.GetByIdHandler(newCommand,token);
            return Ok(response);
        }
    #endregion

    #region </GetFoto>
        [HttpGet("UsuarioFoto"), EndpointSummary("Obter a Foto do Usuario Pelo Id")]
        public async Task<ActionResult> GetFoto([FromQuery] GetUsuarioFotoCommand command, CancellationToken token)
        {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized("Você não está autenticado no sistema.");
                }

                var userId = User.GetId();

                var response = await service.GetFotoHandler(command,token);
                if(response.Data?.FotoUrl == null)
                {
                    return BadRequest("Imagem não encontrada");
                }
                var databyte = System.IO.File.ReadAllBytes(response.Data.FotoUrl);
                return File(databyte, "image/jpg");
        }
    #endregion

    #region </Search>
        [HttpGet("SearchUsuario"), EndpointSummary("Pesquisar Usuarios")]
        [Authorize]
        public async Task<ActionResult> Search([FromQuery] SearchUsuarioCommand command, CancellationToken token)
        {
            var response = await service.SearchHendler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Delete>
        [HttpDelete("DeleteUsuario"), EndpointSummary("Excluir Usuario")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteUsuarioCommand command, CancellationToken token)
        {
            var userId = User.GetId();
            var user = await service.GetByIdHandler(new GetUsuarioByIdCommand { Id = userId }, token);
            if (!(user.Data?.PerfilID == 1))
            {
                return Unauthorized("Você não tem permissão para deletar os usuários do sistema");
            }

            var response = await service.DeleteHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </Update>
        [HttpPut("UpdateUsuario"), EndpointSummary("Atualizar Usuário")]
        public async Task<ActionResult> Update(UpdateUsuarioCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.UpdateHandler(command,token);
            return Ok(response);
        }
    #endregion
    
    #region </Status>
        [HttpPatch("UpdatePerfilUsuario"), EndpointSummary("Atualizar o Perfil do Usuário")]
        public async Task<ActionResult> Update(UsuarioStatusCommand command, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var response = await service.StatusHandler(command,token);
            return Ok(response);
        }
    #endregion

    #region </UpdateFoto>
        [HttpPatch("UpdateUsuarioFoto"), EndpointSummary("Atualizar a Foto do Usuário")]
        public async Task<ActionResult> UpdateFoto([FromForm] UpdateUsuarioFotoModel model, CancellationToken token)
        {
            if(User.FindFirst("id") == null)
            {
                return Unauthorized("Você não está autenticado no sistema.");
            }

            var getCommand = new GetUsuarioByIdCommand { Id = model.Id };
            var result = await service.GetByIdHandler(getCommand, token);

            if (result.Data is null)
                return NotFound("Postagem não encontrada.");

            string caminhoAntigo = result.Data.FotoUrl;
            string caminhoNovo = caminhoAntigo;

            if (model.FotoUrl != null && model.FotoUrl.Length > 0)
            {
                var extensao = Path.GetExtension(model.FotoUrl.FileName).ToLower();
                var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!extensoesPermitidas.Contains(extensao))
                    return BadRequest("Extensão de imagem inválida. Use JPG, JPEG, PNG ou GIF.");

                string pasta = Path.Combine("Storage", "Images");
                Directory.CreateDirectory(pasta);

                string novoNome = $"{Guid.NewGuid()}{extensao}";
                caminhoNovo = Path.Combine(pasta, novoNome);

                await using var stream = new FileStream(caminhoNovo, FileMode.Create);
                await model.FotoUrl.CopyToAsync(stream);

                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);
            }

            var command = new UpdateUsuarioFotoCommand
            {
                Id = model.Id,
                FotoUrl = caminhoNovo
            };

            var response = await service.UpdateFotoHandler(command, token);
            return Ok(response);
        }
    #endregion
}
