using System;
using System.Web;
using BpeCentral.Dominio.Interfaces.Servico;
using System.Security.Cryptography.X509Certificates;
using BpeCentral.Dominio.Repositorio.Interfaces;
using RodoBPe;

namespace BpeCentral.Dominio.Servico
{
    public class CertificadoServico : ICertificadoServico
    {
        #region const
        private const string keyCriptografia = "594d0e5b-cfa0-4579-a0c8-a3864622";
        private const string ivCriptografia = "76cffcdf-d9e5-4a";
        #endregion

        #region prop
        ICertificadoRepositorio _certificadoRepositorio;
        #endregion

        public CertificadoServico(ICertificadoRepositorio certificadoRepositorio)
        {
            _certificadoRepositorio = certificadoRepositorio;
        }

        public bool GravaCertificado(HttpPostedFileBase arquivoCertificado, string senhaCertificado, int codEmitente)
        {

            try
            {
                byte[] arquivoembytes = new byte[arquivoCertificado.ContentLength];

                arquivoCertificado.InputStream.Read(arquivoembytes, 0, arquivoCertificado.ContentLength);

                var cert = new X509Certificate2(arquivoembytes, senhaCertificado);
                string strData = cert.GetExpirationDateString();
                var arquivostringbase64 = Convert.ToBase64String(arquivoembytes);
                var criptografado = Criptografia.Encriptar(keyCriptografia, ivCriptografia, arquivostringbase64);
                string certificado = criptografado;
                string senha = Criptografia.Encriptar(keyCriptografia, ivCriptografia, senhaCertificado);

                arquivoCertificado.InputStream.Close();

                BPE_CERTIFICADO bpeCert = new BPE_CERTIFICADO
                {
                    CODIGO_CONFIGURACAO_EMITENTE = codEmitente,
                    CERTIFICADO = certificado,
                    SENHA = senha,
                    DATA_INICIAL = DateTime.Now,
                    DATA_FINAL = Convert.ToDateTime(strData)
                };


                _certificadoRepositorio.Inserir(bpeCert);
                
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
