using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Dominio.Servico;
using BpeCentral.Repositorio.Repositorios;
using Ninject.Modules;

namespace BpeCentral.IoC.Modules
{
    public class ModulosNinject : NinjectModule
    {
        public override void Load()
        {
            //Bind<ProjetoModeloContext>().ToSelf().InRequestScope();
            
            // Serviço:
            Bind<IUsuarioServico>().To<UsuarioServico>();      
                                    
            // Repositório:
            //Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            Bind<IVersaoDllServicoRepositorio>().To<VersaoDllServicoRepositorio>();
            Bind<IUFTributacaoRepositorio>().To<UFTributacaoRepositorio>();
            Bind<IBpesProcessadosRepositorio>().To<BpesProcessados>();
            Bind<IBpesProcessadosServico>().To<BpesProcessadosServico>();
            Bind<IPainelServico>().To<PainelServico>();
            Bind<IConfiguracaoEmitenteRepositorio>().To<ConfiguracaoEmitenteRepositorio>();
            Bind<IBpesProcessadosXmlServico>().To<BpesProcessadosXmlServico>();
            Bind<IClienteRepositorio>().To<ClienteRepositorio>();
            Bind<ISerieBilheteRepositorio>().To<SerieBilheteRepositorio>();
            Bind<IControleSerieRepositorio>().To<ControleSerieRepositorio>();
            Bind<IBpeTipoAplicacaoRepositorio>().To<BpeTipoAplicacaoRepositorio>();
            Bind<ICertificadoRepositorio>().To<CertificadoRepositorio>();
            Bind<ICertificadoServico>().To<CertificadoServico>();
            Bind<ISchemaRepositorio>().To<SchemaRepositorio>();
            Bind<ISchemaServico>().To<SchemaServico>();
            Bind<IClienteEmitenteRepositorio>().To<ClienteEmitenteRepositorio>();
            Bind<IClienteServico>().To<ClienteServico>();
            Bind<IBpeRepositorio>().To<BpeRepositorio>();
        }
    }
}
