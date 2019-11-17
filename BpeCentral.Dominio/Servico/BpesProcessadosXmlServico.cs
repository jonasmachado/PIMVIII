using System;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using BpeCentral.Dominio.API.Response.Autorizacao;
using System.Web.Script.Serialization;
using BpeCentral.Dominio.API.Response;
using BpeCentral.Dominio.Interfaces.Servico;
using System.IO;
using BpeCentral.Dominio.Comum.Enums;

namespace BpeCentral.Dominio.Servico
{
    public class BpesProcessadosXmlServico : IBpesProcessadosXmlServico
    {
        #region prop
        private readonly string obter_quantidade = "http://bpecentralsite.rodosoft.com.br/webservice/api/bpe/obter_quantidade";
        private readonly string obter_xml        = "http://bpecentralsite.rodosoft.com.br/webservice/api/bpe/obter_proximo_xml";
        private readonly string autorizacao      = "http://bpecentralsite.rodosoft.com.br/webservice/api/autorizacao";
        #endregion

        #region methods

        public HttpStatusCode Autorizar(string usuario, string senha, EstadoEnum codEstado, out string token, out string mensagem)
        {
            string resposta = "";
            token = "";
            string dados = string.Format("Login={0}&Senha={1}&Estado={2}", usuario, senha, (int)codEstado);
            HttpStatusCode ret = MontaPOST(dados, token, autorizacao, ref resposta, out mensagem);

            if (ret == HttpStatusCode.OK)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ResponseAutorizacao response = serializer.Deserialize<ResponseAutorizacao>(resposta);

                token = response.Token;
            }
            else if(ret == HttpStatusCode.Unauthorized)
            {
                mensagem = "Usuario e/ou Senha incorretos";
            }

            return ret;
        }


        public HttpStatusCode ObterQuantidade(string data, string token, out int quantidade, out string mensagem)
        {
            string resposta = "";
            string dados = "Data=" + data;
            HttpStatusCode ret = MontaPOST(dados, token, obter_quantidade, ref resposta, out mensagem);

            quantidade = int.TryParse(resposta, out quantidade) ? quantidade : -1;
            return ret;
        }

        public HttpStatusCode ObterXMLComRetorno(string data, string token, out XmlBpeResponse xmlResp, out string mensagem)
        {
            string resposta = "";
            string dados = "Data=" + data;
            HttpStatusCode ret =  MontaPOST(dados, token, obter_xml, ref resposta, out mensagem);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            xmlResp = serializer.Deserialize<XmlBpeResponse>(resposta);

            return ret;
        }
        
        public HttpStatusCode MontaPOST(string dados, string token, string solicitacao, ref string resposta, out string mensagem)
        {
            mensagem = "Solicitação Ok";

            var request = (HttpWebRequest)WebRequest.Create(solicitacao);
            try
            {

                var dataEmBytes = Encoding.ASCII.GetBytes(dados);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataEmBytes.Length;
                request.Headers["Authorization"] = "Bearer " + token;
                request.Timeout = 15 * 1000;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dataEmBytes, 0, dados.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    resposta = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    mensagem = GeraMensagemErro(httpResponse.StatusCode);

                    return httpResponse.StatusCode;
                }
            }

            return HttpStatusCode.OK;
        }

        private string GeraMensagemErro(HttpStatusCode status)
        {
            string ret = "Erro";

            switch(status)
            {
                case HttpStatusCode.NotFound:
                    ret = "Não foram encontrados dados com os parâmetros fornecidos";     
                    break;
                case HttpStatusCode.Unauthorized:
                    ret = "Usuario não possui autorização ou não foi fornecido um token válido";
                    break;
                case HttpStatusCode.InternalServerError:
                    ret = "Ocorreu um erro ao realizar a solicitação";
                    break;
                case HttpStatusCode.RequestTimeout:
                    ret = "A solicitação demorou demais para ser respondida" ;
                    break;
            }

            return ret;
        }
        #endregion
    }
}
