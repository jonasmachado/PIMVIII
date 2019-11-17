using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Dominio.Interfaces.Servico;
using System;
using BpeCentral.Dominio.Comum.Enums;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Servico
{
    public class BpesProcessadosServico : IBpesProcessadosServico
    {
        IUsuarioRepositorio _usuariosRepositorio;
        IBpesProcessadosRepositorio _bpesProcessadosRepositorio;

        public BpesProcessadosServico(IUsuarioRepositorio usuariosRepositorio, IBpesProcessadosRepositorio bpesProcessadosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _bpesProcessadosRepositorio = bpesProcessadosRepositorio;
        }

        public int Count(int userId, DateTime data, string codEstado)
        {
            int? codigoEmitente = _usuariosRepositorio.ObterCodigoEmitente(userId);

            if (codigoEmitente.HasValue)
            {
                return _bpesProcessadosRepositorio.Count(codigoEmitente.Value, data, codEstado);
            }

            return 0;
        }
        
        public string ObterProximoXML(int userId, DateTime data, string codEstado, out StatusPoximoXml status, ref string chaveBpe)
        {
            status = StatusPoximoXml.Indefinido;
            int? codigoEmitente = _usuariosRepositorio.ObterCodigoEmitente(userId);
            string ret = "";
            if (codigoEmitente.HasValue)
            {
                //obtem dois para que seja possivel definir o status, ou seja, se há ou não (ou pode haver) um proximo xml para a data
                List<BPE_PROCESSADO> bpeList = _bpesProcessadosRepositorio.ObterDois(codigoEmitente.Value, data, codEstado);

                if (bpeList.Count > 0)
                {
                    if (bpeList[0].XML.Length > 0)
                    {
                        ret = bpeList[0].XML;

                        bpeList[0].QUANTIDADE_ENVIOS++;
                        _bpesProcessadosRepositorio.SalvarModificacoes(bpeList[0]);
                        chaveBpe = bpeList[0].CHAVE;
                    }                   
                }
                status = DefineStatus(bpeList, data);
            }

            return ret;
        }

        private StatusPoximoXml DefineStatus(List<BPE_PROCESSADO> bpeList, DateTime data)
        {
            StatusPoximoXml ret = StatusPoximoXml.Indefinido;

            if(bpeList.Count == 1)
            {   
                //entre 0:00h de uma data até 23:59 de outra pode ser autorizado uma nota para o primeiro dia
                if((bpeList[0].DATA_EMISSAO.HasValue) && (DateTime.Now - data).TotalHours > 48) 
                {
                    ret = StatusPoximoXml.Fim;
                }
                else
                {
                    ret = StatusPoximoXml.NaoTem;
                }
            }
            else if(bpeList.Count == 2)
            {
                if (bpeList[0].QUANTIDADE_ENVIOS > bpeList[1].QUANTIDADE_ENVIOS)
                {
                    ret = StatusPoximoXml.Tem;
                }
                else if((DateTime.Now - data).TotalHours < 48)
                {
                    ret = StatusPoximoXml.NaoTem;
                }
                else
                {
                    ret = StatusPoximoXml.Fim;
                }
            }

            return ret;
        }
    }
}
