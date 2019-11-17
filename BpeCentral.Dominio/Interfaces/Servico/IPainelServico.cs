using BpeCentral.Dominio;
using BpeCentral.Dominio.Model;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IPainelServico
    {
        PainelModel RetornaDadosPainelAdministrador();
        PainelModel RetornaDadosPainelUsuario(int codigoEmitente, string codEstado);
    }
}
