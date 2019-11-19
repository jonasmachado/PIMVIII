namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("hwb.trabalho", "dataparaentrega", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("hwb.trabalho", "dataparaentrega", c => c.DateTime(nullable: false));
        }
    }
}
