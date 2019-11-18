namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1012 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("public.itemestoque");
            AddPrimaryKey("public.itemestoque", new[] { "codigoproduto", "codigoestoque" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("public.itemestoque");
            AddPrimaryKey("public.itemestoque", "id_itemestoque");
        }
    }
}
