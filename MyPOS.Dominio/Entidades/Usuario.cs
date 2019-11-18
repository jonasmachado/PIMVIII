using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPOS.Dominio.Entidades
{
    [Table("usuario", Schema ="public")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usuario")]
        public int Id_Usuario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("login")]
        [Key]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("eperfil")]
        public int PerfilUsuario { get; set; }
    }
}
