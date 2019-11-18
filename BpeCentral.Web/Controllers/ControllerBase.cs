using AutoMapper;
using MyPOS.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BpeCentral.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected List<TViewModel> Listagem<TViewModel, TEntity, TInterface>(TInterface _interface)
        {
            List<TViewModel> ret = new List<TViewModel>();

            List<TEntity> result = ((IRepositorioBase<TEntity>)_interface).ObterTodos();

            if (result != null && result.Count > 0)
                ret = Mapper.Map<List<TEntity>, List<TViewModel>>(result);

            return ret;
        }     

        protected void Cadastrar<TViewModel, TEntity, TInterface>(TInterface _interface, TViewModel obj)
        {
            var objIncluir = Mapper.Map<TViewModel, TEntity>(obj);
            ((IRepositorioBase<TEntity>)_interface).InserirNovo(objIncluir);
        }

        protected void Modificar<TViewModel, TEntity, TInterface>(TInterface _interface, TViewModel obj)
        {
            var objIncluir = Mapper.Map<TViewModel, TEntity>(obj);
            ((IRepositorioBase<TEntity>)_interface).SalvarModificacoes(objIncluir);
        }

        protected void Remover<TViewModel, TEntity, TInterface>(TInterface _interface, TViewModel obj)
        {
            var objRemover = Mapper.Map<TViewModel, TEntity>(obj);
            ((IRepositorioBase<TEntity>)_interface).SalvarModificacoes(objRemover);
        }
    }
}