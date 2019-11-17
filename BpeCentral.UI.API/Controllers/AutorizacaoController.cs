using BpeCentral.API.Tokenizacao;
using BpeCentral.Dominio;
using BpeCentral.Dominio.API.Request.Autorizacao;
using BpeCentral.Dominio.API.Response.Autorizacao;
using BpeCentral.Dominio.Interfaces.Servico;
using Swashbuckle.Swagger.Annotations;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;

namespace BpeCentral.UI.API.Controllers
{
    [RoutePrefix("api/autorizacao")]
    public class AutorizacaoController : ApiController
    {
        IUsuarioServico _usuarioServico;

        public AutorizacaoController(IUsuarioServico usuarioRepositorio)
        {
            _usuarioServico = usuarioRepositorio;
        }

        [HttpPost]
        [ResponseType(typeof(ResponseAutorizacao))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Necessario informar Login e Senha")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Usuario não autorizado ou não encontrado.")]
        [Route("")]
        public IHttpActionResult ObterAutorizacao([FromBody] RequestAutorizacao request_autorizacao)
        {
            if (ValidaRequestAutorizacao(request_autorizacao))
                return BadRequest("Necessario informar Login e Senha");

            BPE_USUARIOS user = _usuarioServico.Autenticacao(request_autorizacao.Login, request_autorizacao.Senha);
            if (user != null)
            {
                Token token = new Token();
                return Ok(new ResponseAutorizacao()
                {
                    Email = user.EMAIL,
                    Nome = user.NOME,
                    Token = token.Generate(user.ID, new System.Security.Claims.Claim[] {
                        new System.Security.Claims.Claim("codEmpresa",user.CODIGO_EMPRESA.ToString()),
                        new System.Security.Claims.Claim("Estado","" + (int)request_autorizacao.Estado)
                    }),
                    ID = user.ID
                    
                });
            }
            
            return NotFound();
        }

        static bool ValidaRequestAutorizacao(RequestAutorizacao request_autorizacao)
        {
            if (request_autorizacao == null) return false;
            return string.IsNullOrWhiteSpace(request_autorizacao.Login) || string.IsNullOrWhiteSpace(request_autorizacao.Senha);
        }
    }
}
