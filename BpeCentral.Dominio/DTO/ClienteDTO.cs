namespace BpeCentral.Dominio.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string TipoCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }
        public string Email { get; set; }
    }
}
