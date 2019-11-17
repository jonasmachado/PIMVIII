using System;
using BpeCentral.Dominio.Interfaces.Servico;
using System.Linq;
using BpeCentral.Dominio.Repositorio.Interfaces;

namespace BpeCentral.Dominio.Servico
{
    public class ClienteServico : IClienteServico
    {

        #region prop
        IClienteRepositorio _clienteRepositorio;
        #endregion

        #region ctor

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        #endregion

        #region métodos

        private void Formata(BPE_CLIENTE cliente)
        {
            cliente.CNPJ = new String(cliente.CNPJ.Where(Char.IsDigit).ToArray());
            cliente.TELEFONE = new String(cliente.TELEFONE.Where(Char.IsDigit).ToArray());
            cliente.DATA = DateTime.Now;
        }

        public void InsereFormatado(BPE_CLIENTE cliente)
        {
            Formata(cliente);
            _clienteRepositorio.InserirNovo(cliente);
        }

        public void SalvaFormatado(BPE_CLIENTE cliente)
        {
            Formata(cliente);
            _clienteRepositorio.SalvarModificacoes(cliente);
        }
        #endregion
    }
}
