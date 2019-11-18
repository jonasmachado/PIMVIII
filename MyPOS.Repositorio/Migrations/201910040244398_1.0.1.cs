namespace MyPOS.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.compras",
                c => new
                    {
                        id_compra = c.Int(nullable: false, identity: true),
                        datacompra = c.DateTime(nullable: false),
                        cpf = c.String(),
                        codigousuario = c.Int(nullable: false),
                        cancelada = c.Boolean(nullable: false),
                        caixa = c.Int(nullable: false),
                        nsu = c.Int(nullable: false),
                        valorcompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id_compra);
            
            CreateTable(
                "public.comprovante",
                c => new
                    {
                        id_comprovante = c.Int(nullable: false, identity: true),
                        numerocaixa = c.Int(nullable: false),
                        codigo = c.Int(nullable: false),
                        operador = c.String(),
                        valortotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        valortributos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valorpagamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        valorrecebido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        formapagamento = c.Int(nullable: false),
                        troca = c.Decimal(nullable: false, precision: 18, scale: 2),
                        datahora = c.DateTime(nullable: false),
                        codigoempresa = c.Int(nullable: false),
                        Empresa_CNPJ = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_comprovante)
                .ForeignKey("public.empresa", t => t.Empresa_CNPJ)
                .Index(t => t.Empresa_CNPJ);
            
            CreateTable(
                "public.empresa",
                c => new
                    {
                        cnpj = c.String(nullable: false, maxLength: 128),
                        id_empresa = c.Int(nullable: false, identity: true),
                        razaosocial = c.String(),
                        telefone = c.String(),
                    })
                .PrimaryKey(t => t.cnpj);
            
            CreateTable(
                "public.itemcompra",
                c => new
                    {
                        id_itemcompra = c.Int(nullable: false, identity: true),
                        codigoproduto = c.Int(nullable: false),
                        codigocompra = c.Int(nullable: false),
                        quantidade = c.Int(nullable: false),
                        Comprovante_Id_Comprovante = c.Int(),
                    })
                .PrimaryKey(t => t.id_itemcompra)
                .ForeignKey("public.comprovante", t => t.Comprovante_Id_Comprovante)
                .Index(t => t.Comprovante_Id_Comprovante);
            
            CreateTable(
                "public.controledecaixa",
                c => new
                    {
                        id_controledecaixa = c.Int(nullable: false, identity: true),
                        abertura = c.DateTime(nullable: false),
                        fechamento = c.DateTime(),
                        sequencial = c.Int(nullable: false),
                        numerodocaixa = c.Int(nullable: false),
                        codigooperador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_controledecaixa)
                .ForeignKey("public.usuario", t => t.codigooperador, cascadeDelete: true)
                .Index(t => t.codigooperador);
            
            CreateTable(
                "public.usuario",
                c => new
                    {
                        id_usuario = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        login = c.String(),
                        senha = c.String(),
                        codigoestoque = c.Int(nullable: false),
                        eperfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_usuario)
                .ForeignKey("public.estoque", t => t.codigoestoque, cascadeDelete: true)
                .Index(t => t.codigoestoque);
            
            CreateTable(
                "public.estoque",
                c => new
                    {
                        id_estoque = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id_estoque);
            
            CreateTable(
                "public.itemestoque",
                c => new
                    {
                        id_itemestoque = c.Int(nullable: false, identity: true),
                        codigoproduto = c.Int(nullable: false),
                        codigoestoque = c.Int(nullable: false),
                        quantidade = c.Int(nullable: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        precocompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Produto_Id_Produto = c.Int(),
                    })
                .PrimaryKey(t => t.id_itemestoque)
                .ForeignKey("public.estoque", t => t.codigoestoque, cascadeDelete: true)
                .ForeignKey("public.produto", t => t.Produto_Id_Produto)
                .Index(t => t.codigoestoque)
                .Index(t => t.Produto_Id_Produto);
            
            CreateTable(
                "public.produto",
                c => new
                    {
                        id_produto = c.Int(nullable: false, identity: true),
                        codigo_identificacao = c.String(),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id_produto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.itemestoque", "Produto_Id_Produto", "public.produto");
            DropForeignKey("public.itemestoque", "codigoestoque", "public.estoque");
            DropForeignKey("public.controledecaixa", "codigooperador", "public.usuario");
            DropForeignKey("public.usuario", "codigoestoque", "public.estoque");
            DropForeignKey("public.itemcompra", "Comprovante_Id_Comprovante", "public.comprovante");
            DropForeignKey("public.comprovante", "Empresa_CNPJ", "public.empresa");
            DropIndex("public.itemestoque", new[] { "Produto_Id_Produto" });
            DropIndex("public.itemestoque", new[] { "codigoestoque" });
            DropIndex("public.usuario", new[] { "codigoestoque" });
            DropIndex("public.controledecaixa", new[] { "codigooperador" });
            DropIndex("public.itemcompra", new[] { "Comprovante_Id_Comprovante" });
            DropIndex("public.comprovante", new[] { "Empresa_CNPJ" });
            DropTable("public.produto");
            DropTable("public.itemestoque");
            DropTable("public.estoque");
            DropTable("public.usuario");
            DropTable("public.controledecaixa");
            DropTable("public.itemcompra");
            DropTable("public.empresa");
            DropTable("public.comprovante");
            DropTable("public.compras");
        }
    }
}
