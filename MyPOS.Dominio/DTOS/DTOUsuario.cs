namespace MyPOS.Dominio.DTOS
{
    public class DTOUsuario
    {
        public int Id_Usuario { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
        public int CodigoEstoque { get; set; }

        public int PerfilUsuario { get; set; }
    }
}
