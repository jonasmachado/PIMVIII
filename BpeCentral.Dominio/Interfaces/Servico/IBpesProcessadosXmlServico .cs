using BpeCentral.Dominio.API.Response;
using BpeCentral.Dominio.API.Response.Autorizacao;
using BpeCentral.Dominio.Comum.Enums;
using System.Net;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IBpesProcessadosXmlServico
    {
        HttpStatusCode Autorizar(string usuario, string senha, EstadoEnum codEstado, out string token, out string mensagem);
        HttpStatusCode ObterQuantidade(string data, string token, out int quantidade, out string mensagem);
        HttpStatusCode ObterXMLComRetorno(string data, string token, out XmlBpeResponse xmlResp, out string mensagem);
    }
}
