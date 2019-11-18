namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _102 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.controledecaixa", "codigooperador", "public.usuario");
            DropForeignKey("public.itemestoque", "codigoproduto", "public.produto");
            DropIndex("public.controledecaixa", new[] { "codigooperador" });
            DropIndex("public.itemestoque", new[] { "codigoproduto" });
            RenameColumn(table: "public.itemestoque", name: "codigoproduto", newName: "codigoidentificacacaoproduto");
            DropPrimaryKey("public.compras");
            DropPrimaryKey("public.controledecaixa");
            DropPrimaryKey("public.usuario");
            DropPrimaryKey("public.itemestoque");
            DropPrimaryKey("public.produto");
            AddColumn("public.itemcompra", "codigoidentificacaoproduto", c => c.String());
            AlterColumn("public.controledecaixa", "codigooperador", c => c.String(maxLength: 128));
            AlterColumn("public.usuario", "login", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("public.itemestoque", "codigoidentificacacaoproduto", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("public.produto", "codigo_identificacao", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("public.compras", new[] { "nsu", "caixa" });
            AddPrimaryKey("public.controledecaixa", new[] { "sequencial", "numerodocaixa" });
            AddPrimaryKey("public.usuario", "login");
            AddPrimaryKey("public.itemestoque", new[] { "codigoidentificacacaoproduto", "codigoestoque" });
            AddPrimaryKey("public.produto", "codigo_identificacao");
            CreateIndex("public.controledecaixa", "codigooperador");
            CreateIndex("public.itemestoque", "codigoidentificacacaoproduto");
            AddForeignKey("public.controledecaixa", "codigooperador", "public.usuario", "login");
            AddForeignKey("public.itemestoque", "codigoidentificacacaoproduto", "public.produto", "codigo_identificacao", cascadeDelete: true);
            DropColumn("public.itemcompra", "codigoproduto");
        }
        
        public override void Down()
        {
            AddColumn("public.itemcompra", "codigoproduto", c => c.Int(nullable: false));
            DropForeignKey("public.itemestoque", "codigoidentificacacaoproduto", "public.produto");
            DropForeignKey("public.controledecaixa", "codigooperador", "public.usuario");
            DropIndex("public.itemestoque", new[] { "codigoidentificacacaoproduto" });
            DropIndex("public.controledecaixa", new[] { "codigooperador" });
            DropPrimaryKey("public.produto");
            DropPrimaryKey("public.itemestoque");
            DropPrimaryKey("public.usuario");
            DropPrimaryKey("public.controledecaixa");
            DropPrimaryKey("public.compras");
            AlterColumn("public.produto", "codigo_identificacao", c => c.String());
            AlterColumn("public.itemestoque", "codigoidentificacacaoproduto", c => c.Int(nullable: false));
            AlterColumn("public.usuario", "login", c => c.String());
            AlterColumn("public.controledecaixa", "codigooperador", c => c.Int(nullable: false));
            DropColumn("public.itemcompra", "codigoidentificacaoproduto");
            AddPrimaryKey("public.produto", "id_produto");
            AddPrimaryKey("public.itemestoque", new[] { "codigoproduto", "codigoestoque" });
            AddPrimaryKey("public.usuario", "id_usuario");
            AddPrimaryKey("public.controledecaixa", "id_controledecaixa");
            AddPrimaryKey("public.compras", "id_compra");
            RenameColumn(table: "public.itemestoque", name: "codigoidentificacacaoproduto", newName: "codigoproduto");
            CreateIndex("public.itemestoque", "codigoproduto");
            CreateIndex("public.controledecaixa", "codigooperador");
            AddForeignKey("public.itemestoque", "codigoproduto", "public.produto", "id_produto", cascadeDelete: true);
            AddForeignKey("public.controledecaixa", "codigooperador", "public.usuario", "id_usuario", cascadeDelete: true);
        }
    }
}
