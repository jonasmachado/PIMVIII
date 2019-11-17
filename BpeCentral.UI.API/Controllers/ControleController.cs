using BpeCentral.Dominio.Comum.Request;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using BpeCentral.API.Filters;
using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.API.Response;
using BpeCentral.Dominio.Comum.Enums;
using System.Net.Http.Headers;
using BpeCentral.API.Tokenizacao;
using System.Linq;
using BpeCentral.Dominio.Repositorio.Interfaces;

namespace BpeCentral.UI.API.Controllers
{
    [RoutePrefix("api")]
    public class BpesController : ApiController
    {

        readonly IBpesProcessadosServico _bpesProcessadosServico;
        private readonly IBpesProcessadosRepositorio _bpesProcessadosRepositorio;
        private readonly IBpeRepositorio _bpeRepositorio;

        public BpesController(IBpesProcessadosServico bpesProcessadosServico, IBpesProcessadosRepositorio bpesProcessadosRepositorio, IBpeRepositorio bpeRepositorio)
        {
            _bpesProcessadosServico = bpesProcessadosServico;
            _bpesProcessadosRepositorio = bpesProcessadosRepositorio;
            _bpeRepositorio = bpeRepositorio;
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.NotFound, "Não foram encontrados dados nesses parametros.")]
        [Route("bpe/obter_quantidade")]
        [TokenAuthorize]
        public IHttpActionResult obter_quantidade([FromBody]XmlBpeRequest request)
        {
            int idUser = ObtemIdUser();
            if (idUser > 0)
            {
                int ret = _bpesProcessadosServico.Count(idUser, request.GetData(), getEstado());
                return Ok(ret);
            }
            
            return NotFound();
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.NotFound, "Não foram encontrados dados nesses parametros.")]
        [Route("bpe/obter_proximo_xml")]    
        [TokenAuthorize]
        public IHttpActionResult obter_proximo_xml([FromBody]XmlBpeRequest request)
        {
            string chaveBpe = "";
            string rawXml = _bpesProcessadosServico.ObterProximoXML(ObtemIdUser(), request.GetData(), getEstado(), out var status, ref chaveBpe);
            XmlBpeResponse xmlResponse = new XmlBpeResponse(status, rawXml, chaveBpe);

            if (rawXml.Length == 0)
            {
                return NotFound();
            }
            
            return Ok(xmlResponse);
        }


        [HttpPost]
        [SwaggerResponse(HttpStatusCode.NotFound, "Não foram encontrados dados nesses parametros.")]
        [Route("bpe/obter_xml")]
        public IHttpActionResult obter_xml([FromBody]XmlPorChaveRequest request)
        {
            if (request == null)
                return BadRequest();

            XmlPorChaveResponse xmlResponse;

            var processado = _bpesProcessadosRepositorio.ObterXmlPorChave(request.Chave);

            if (processado == null)
            {
                var bpe = _bpeRepositorio.ObterPorChave(request.Chave);

                if (bpe == null)
                    return NotFound();

                xmlResponse = new XmlPorChaveResponse { Xml = bpe.XML };
            }
            else
            {
                xmlResponse = new XmlPorChaveResponse { Xml = processado.XML };
            }   
            

            return Ok(xmlResponse);
        }

        private int ObtemIdUser()
        {
            int.TryParse(User.Identity.Name, out int ret);
            return ret;
        }

        private string getEstado()
        {
            AuthenticationHeaderValue authorization = ControllerContext.Request.Headers.Authorization;
            Token token = new Token();
            var stoken = token.ConvertToken(authorization.Parameter);
            var estado = stoken.Claims.FirstOrDefault(x => x.Type == "Estado");

            return estado.Value;
        }
    }
}
