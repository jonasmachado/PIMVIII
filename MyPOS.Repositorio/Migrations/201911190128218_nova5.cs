namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("hwb.trabalho");
            AlterColumn("hwb.trabalho", "titulo", c => c.String());
            AddPrimaryKey("hwb.trabalho", "id_trabalho");
        }
        
        public override void Down()
        {
            DropPrimaryKey("hwb.trabalho");
            AlterColumn("hwb.trabalho", "titulo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("hwb.trabalho", "titulo");
        }
    }
}
