namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opcional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.itemestoque", "inclusao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("public.itemestoque", "inclusao", c => c.DateTime(nullable: false));
        }
    }
}
