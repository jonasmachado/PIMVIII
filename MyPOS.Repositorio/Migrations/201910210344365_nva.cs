namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nva : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.itemcompra", "preco", c => c.Decimal(nullable: true, precision: 18, scale: 2));
            AddColumn("public.itemestoque", "inclusao", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("public.itemestoque", "inclusao");
            DropColumn("public.itemcompra", "preco");
        }
    }
}
