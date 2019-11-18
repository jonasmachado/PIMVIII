using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Dominio.Interfaces.Servicos;
using MyPOS.Dominio.Servicos;
using MyPOS.Repositorio.Repositorio;
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
            Bind<ITrabalhoRepositorio>().To<TrabalhoRepositorio>();

        }
    }
}
