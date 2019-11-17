namespace BpeCentral.Dominio.API.Response.Autorizacao
{
    public class ResponseAutorizacao
    {
        public string Token { get; set; }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }       

        public string Mensagem { get; set; }
    }
}
