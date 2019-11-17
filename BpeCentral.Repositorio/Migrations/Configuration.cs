using System;


namespace BpeCentral.Repositorio.Migrations
{
    using BpeCentral.Dominio;
    using System.Data.Entity.Migrations;
    /*
    internal sealed class Configuration : DbMigrationsConfiguration<BPE_USUARIOS>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Pode resultar em perda de dados
        }

        protected override void Seed(ProjetoModeloContext context)
        {
            #region [ add Usuarios ]
            context.Usuarios.AddOrUpdate(u => u.Email,
                new Usuario()
                {
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    Email = "rodosoft@rodosoft.com.br",
                    Nome = "Admin Rodosoft",
                    Perfil = 1,
                    Senha = "4BADAEE57FED5610012A296273158F5F" //102030               
                });
            #endregion

            //#region [ Modalidades ]
            //context.Modalidade.AddOrUpdate(c => c.Descricao,
            //    new Dominio.Entidades.Modalidade() { Descricao = "Comum" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Semi - Direto" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Plano-Praia"},
            //    new Dominio.Entidades.Modalidade() { Descricao = "Leito" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Executivo" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Direto" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Dir-Plano-Praia" },
            //    new Dominio.Entidades.Modalidade() { Descricao = "Leito Cama" }
            //    );
            //#endregion

            context.SaveChanges();

            //context.EmpresaDeTransporte.AddOrUpdate(c => c.Nome,
            //    new EmpresaDeTransporte()
            //    {
            //        Nome = "Viação Outro e Prata",
            //        NomeFantasia = "Outro e Prata",
            //        Rua = "R. Frederico Mentz",
            //        Numero = "1419",
            //        Bairro = "R. Frederico Mentz",
            //        Cep = "93400000",
            //        Cidade = "Porto Alegre",
            //        Estado = "RS",
            //        Cnpj = "92954106000142",
            //        Usuario = new Usuario()
            //        {
            //            Ativo = true,
            //            DataCadastro = DateTime.Now,
            //            Email = "ti@ouroeprata.com.br",
            //            Nome = "Outro e Prata",
            //            Perfil = (int)EPerfilUsuario.EmpresaDeTransporte,
            //            Senha = "E10ADC3949BA59ABBE56E057F20F883E" //123456
            //        },
            //        ContratoEmpresaDeTransporte = new Dominio.Entidades.Contrato.ContratoEmpresaDeTransporte(true, true,false, false)
            //    },
            //    new EmpresaDeTransporte()
            //    {
            //        Nome = "Viação Planalto",
            //        NomeFantasia = "Planalto",
            //        Rua = "R. Frederico Mentz",
            //        Numero = "1420",
            //        Bairro = "Frederico Mentz",
            //        Cep = "93400010",
            //        Cidade = "Porto Alegre",
            //        Estado = "RS",
            //        Cnpj = "92954106000152",
            //        Usuario = new Usuario()
            //        {
            //            Ativo = true,
            //            DataCadastro = DateTime.Now,
            //            Email = "ti@planalto.com.br",
            //            Nome = "Panalto",
            //            Perfil = (int)EPerfilUsuario.EmpresaDeTransporte,
            //            Senha = "E10ADC3949BA59ABBE56E057F20F883E" //123456
            //        },
            //        ContratoEmpresaDeTransporte = new Dominio.Entidades.Contrato.ContratoEmpresaDeTransporte(true, true, false, false)
            //    });

            //context.SaveChanges();

            //var empIdOuro = context.EmpresaDeTransporte
            //    .Where(x => x.Nome == "Viação Outro e Prata")
            //    .Select(x => x.EmpresaDeTransporteId)
            //    .FirstOrDefault();

            //var empIdPlan = context.EmpresaDeTransporte
            //   .Where(x => x.Nome == "Viação Planalto")
            //   .Select(x => x.EmpresaDeTransporteId)
            //   .FirstOrDefault();

            //context.ClienteEmpresa.AddOrUpdate(c => c.Nome,
            //    new ClienteEmpresa()
            //    {
            //        Nome = "Loja Roupas",
            //        Cnpj = "93113751000103",
            //        Saldo = 500,
            //        EmpresaDeTransporteId = empIdOuro,
            //        Usuario = new Usuario()
            //        {
            //            Ativo = true,
            //            Perfil = (int)EPerfilUsuario.ClienteEmpresa,
            //            Email = "ti@lojaroupas.com.br",
            //            Nome = "Marcia Francis",
            //            Senha = SenhaHelper.GerarHash("123456")
            //        },
            //        ContratoEmpresaDeTransporteClienteEmpresa = new ContratoEmpresaDeTransporteClienteEmpresa(empIdOuro, 10,true, true, false, false)
            //    });

            //context.ClienteEmpresa.AddOrUpdate(c => c.Nome,
            //   new ClienteEmpresa()
            //   {
            //       Nome = "Loja Tintas",
            //       Cnpj = "92312323423423",
            //       Saldo = 200,
            //       EmpresaDeTransporteId = empIdOuro,
            //       Usuario = new Usuario()
            //       {
            //           Ativo = true,
            //           Perfil = (int)EPerfilUsuario.ClienteEmpresa,
            //           Email = "ti@lojatintas.com.br",
            //           Nome = "Marcos Tinn",
            //           Senha = SenhaHelper.GerarHash("123456")
            //       },
            //       ContratoEmpresaDeTransporteClienteEmpresa = new ContratoEmpresaDeTransporteClienteEmpresa(empIdOuro, 10, true,true, false, false)
            //   });


            //context.ClienteEmpresa.AddOrUpdate(c => c.Nome,
            //  new ClienteEmpresa()
            //  {
            //      Nome = "Loja Peças Carro",
            //      Cnpj = "92312323423587",
            //      Saldo = 100,
            //      EmpresaDeTransporteId = empIdPlan,
            //      Usuario = new Usuario()
            //      {
            //          Ativo = true,
            //          Perfil = (int)EPerfilUsuario.ClienteEmpresa,
            //          Email = "ti@pecascarro.com.br",
            //          Nome = "Fernando Macedo",
            //          Senha = SenhaHelper.GerarHash("123456")
            //      },
            //      ContratoEmpresaDeTransporteClienteEmpresa = new ContratoEmpresaDeTransporteClienteEmpresa(empIdPlan, 10, true,true, false, false)
            //  });


            //context.SaveChanges();

            //context.Governo.AddOrUpdate(c => c.Descricao,
            //    new Governo() { Descricao = "Polícia Civil RS" });

            //context.Localidade.AddOrUpdate(c => c.Descricao,
            //    new Localidade()
            //    {
            //        Ativo = true,
            //        Descricao = "São Leopoldo",
            //        Abreviacao = "Sao Leo",
            //        Estado = "RS",
            //        CodigoIbge = "431870505000001"
            //    },
            //    new Localidade()
            //    {
            //        Ativo = true,
            //        Descricao = "Porto Alegre",
            //        Abreviacao = "POA",
            //        Estado = "RS",
            //        CodigoIbge = "431870515000001"
            //    }
            //    ,
            //    new Localidade()
            //    {
            //        Ativo = true,
            //        Descricao = "Canoas",
            //        Abreviacao = "Canoas",
            //        Estado = "RS",
            //        CodigoIbge = "431870535000001"
            //    }
            //    );



            //context.TipoDeCartao.AddOrUpdate(c => c.Descricao,
            //    new TipoDeCartao() { Descricao = "Vale Transporte" },
            //    new TipoDeCartao() { Descricao = "Cartão" },
            //    new TipoDeCartao() { Descricao = "Idoso" },
            //    new TipoDeCartao() { Descricao = "Deficiente" }
            //    );

            //context.SaveChanges();


        
    }*/
}
