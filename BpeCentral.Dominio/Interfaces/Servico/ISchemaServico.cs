using System;
using System.Collections.Generic;
using System.Web;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface ISchemaServico
    {
        Dictionary<string, string> GravaSchema(HttpPostedFileBase[] arquivos);
    }
}
