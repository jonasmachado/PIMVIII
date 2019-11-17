using BpeCentral.Dominio.Comum.Enums;
using System.Xml;

namespace BpeCentral.Dominio.API.Response
{
    public class XmlBpeResponse
    {
        public int Status { get; set; }
        public string Xml { get; set; }

        public string ChaveBpe { get; set; }
        public XmlBpeResponse(StatusPoximoXml status, string rawXml, string chave)
        {
            Status = (int)status;
            Xml = rawXml;
            ChaveBpe = chave;
        }

        public XmlBpeResponse() {}
    }
}
