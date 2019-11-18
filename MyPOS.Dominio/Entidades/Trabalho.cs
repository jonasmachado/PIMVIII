using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPOS.Dominio.Entidades
{
    [Table("trabalho", Schema = "hwb")]
    public class Trabalho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_trabalho")]
        public int Id_Trabalho { get; set; }

        [Key]
        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("materia")]
        public string Materia { get; set; }

        [Column("entregue")]
        public bool Entregue { get; set; }

        [Column("dataparaentrega")]
        public DateTime DataParaEntrega { get; set; }
    }
}
