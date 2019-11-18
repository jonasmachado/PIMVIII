namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "hwb.trabalho",
                c => new
                    {
                        titulo = c.String(nullable: false, maxLength: 128),
                        id_trabalho = c.Int(nullable: false, identity: true),
                        entregue = c.Boolean(nullable: false),
                        dataparaentrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.titulo);
            
            CreateTable(
                "hwb.usuario",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        id_usuario = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        senha = c.String(),
                        eperfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.email);
            
        }
        
        public override void Down()
        {
            DropTable("hwb.usuario");
            DropTable("hwb.trabalho");
        }
    }
}
