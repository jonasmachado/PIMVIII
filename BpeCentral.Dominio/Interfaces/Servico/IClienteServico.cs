using System;
using System.Web;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IClienteServico
    {
        void InsereFormatado(BPE_CLIENTE cliente);
        void SalvaFormatado(BPE_CLIENTE cliente);
    }
}
