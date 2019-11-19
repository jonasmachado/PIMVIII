namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("hwb.trabalho", "materia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("hwb.trabalho", "materia");
        }
    }
}
