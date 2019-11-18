namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.itemestoque", "Produto_Id_Produto", "public.produto");
            DropIndex("public.itemestoque", new[] { "Produto_Id_Produto" });
            DropColumn("public.itemestoque", "codigoproduto");
            RenameColumn(table: "public.itemestoque", name: "Produto_Id_Produto", newName: "codigoproduto");
            AlterColumn("public.itemestoque", "codigoproduto", c => c.Int(nullable: false));
            CreateIndex("public.itemestoque", "codigoproduto");
            AddForeignKey("public.itemestoque", "codigoproduto", "public.produto", "id_produto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.itemestoque", "codigoproduto", "public.produto");
            DropIndex("public.itemestoque", new[] { "codigoproduto" });
            AlterColumn("public.itemestoque", "codigoproduto", c => c.Int());
            RenameColumn(table: "public.itemestoque", name: "codigoproduto", newName: "Produto_Id_Produto");
            AddColumn("public.itemestoque", "codigoproduto", c => c.Int(nullable: false));
            CreateIndex("public.itemestoque", "Produto_Id_Produto");
            AddForeignKey("public.itemestoque", "Produto_Id_Produto", "public.produto", "id_produto");
        }
    }
}
