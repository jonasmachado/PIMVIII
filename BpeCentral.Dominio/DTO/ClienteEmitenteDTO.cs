using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpeCentral.Dominio.DTO
{
    public class ClienteEmitenteDTO

    {
        public int ID { get; set; }
        public int CODIGO_EMITENTE { get; set; }
        public int CODIGO_CLIENTE { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string MUNICIPIO_CLIENTE { get; set; }
        public string NOME_EMITENTE { get; set; }
        public string UF_EMITENTE { get; set; }
    }
}
