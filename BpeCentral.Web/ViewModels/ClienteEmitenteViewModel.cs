using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Web.ViewModels
{
    public class ClienteEmitenteViewModel
    {
        [Key]
        public int ID { get; set; }
        public int CODIGO_EMITENTE { get; set; }
        public int CODIGO_CLIENTE { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string MUNICIPIO_CLIENTE { get; set; }
        public string NOME_EMITENTE { get; set; }
        public string UF_EMITENTE { get; set; }
    }
}