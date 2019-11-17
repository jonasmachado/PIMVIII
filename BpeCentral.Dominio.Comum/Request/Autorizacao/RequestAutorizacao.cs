using BpeCentral.Dominio.Comum.Enums;

namespace BpeCentral.Dominio.API.Request.Autorizacao
{
    public  class RequestAutorizacao
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public EstadoEnum Estado { get; set; }
    }
}
