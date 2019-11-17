using BpeCentral.Dominio.Comum.Enums;
using System;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IBpesProcessadosServico
    {
        int Count(int userId, DateTime data, string codEstado);
        string ObterProximoXML(int userId, DateTime data, string codEstado, out StatusPoximoXml status, ref string chaveBpe);
    }
}
