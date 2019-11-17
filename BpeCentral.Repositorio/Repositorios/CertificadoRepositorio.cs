using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;

namespace BpeCentral.Repositorio.Repositorios
{
    public class CertificadoRepositorio : BaseCrudDao<BPE_CERTIFICADO>, ICertificadoRepositorio
    {
        public void Inserir(BPE_CERTIFICADO bpeCertificado)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                
                    context.Database.ExecuteSqlCommand("Insert into BPE_CERTIFICADO (CODIGO_CONFIGURACAO_EMITENTE, CERTIFICADO, SENHA, DATA_INICIAL, DATA_FINAL, VERSAO)" +
                                                       "    Values({0},{1},{2},{3},{4},{5} )", bpeCertificado.CODIGO_CONFIGURACAO_EMITENTE, bpeCertificado.CERTIFICADO,
                                                       bpeCertificado.SENHA, bpeCertificado.DATA_INICIAL, bpeCertificado.DATA_FINAL, bpeCertificado.VERSAO);
              
            }
        }
    }
}
