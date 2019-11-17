using System;
using System.Web;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface ICertificadoServico
    {
        bool GravaCertificado(HttpPostedFileBase caminhoCertificado, string senhaCertificado, int codEmitente);

    }
}
