using System;
using System.Collections.Generic;
using System.Web;
using BpeCentral.Dominio.Interfaces.Servico;
using System.IO;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Text;

namespace BpeCentral.Dominio.Servico
{
    public class SchemaServico : ISchemaServico
    {
        #region const
        private const string keyCriptografia = "594d0e5b-cfa0-4579-a0c8-a3864622";
        private const string ivCriptografia = "76cffcdf-d9e5-4a";
        #endregion

        #region prop
        ISchemaRepositorio _schemaRepositorio;
        #endregion

        public SchemaServico(ISchemaRepositorio schemaRepositorio)
        {
            _schemaRepositorio = schemaRepositorio;
        }

        public Dictionary<string, string> GravaSchema(HttpPostedFileBase[] arquivos)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();

            foreach (var arquivo in arquivos)
            {
                if (arquivo == null || arquivo.ContentLength < 0)
                    continue;
                
                try
                {
                    byte[] arquivoembytes = new byte[arquivo.ContentLength];
                    string nomeArquivo = Path.GetFileNameWithoutExtension(arquivo.FileName);

                    arquivo.InputStream.Read(arquivoembytes, 0, arquivo.ContentLength);
                    BPE_SCHEMA schema = new BPE_SCHEMA
                    {
                        NOME = nomeArquivo,
                        REGRAS = arquivoembytes,
                        DATA_ALTERACAO = DateTime.Now,
                        DATA_INCLUSAO = DateTime.Now
                    };

                    if (_schemaRepositorio.ObterPorNome(nomeArquivo) == null)
                    {
                        _schemaRepositorio.Inserir(schema);
                        ret.Add(nomeArquivo, "OK");
                    }
                    else
                    {
                       ret.Add(nomeArquivo, "Já existe um registro com o mesmo nome");
                    }                 
                }
                catch (Exception ex)
                {
                    ret.Add(Path.GetFileNameWithoutExtension(arquivo.FileName), ex.Message);
                }
            }
            return ret;
        }
    }
}
