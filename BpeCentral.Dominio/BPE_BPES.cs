//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BpeCentral.Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class BPE_BPES
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DATA_EMISSAO { get; set; }
        public int CODIGO_EMITENTE { get; set; }
        public int SERIE { get; set; }
        public Nullable<int> SUB_SERIE { get; set; }
        public int NUMERO_BILHETE { get; set; }
        public string CHAVE { get; set; }
        public string PROTOCOLO { get; set; }
        public string XML { get; set; }
        public string AGENCIA { get; set; }
        public Nullable<System.DateTime> DATA_CANCELAMENTO { get; set; }
        public Nullable<System.DateTime> DATA_NAO_EMBARQUE { get; set; }
        public Nullable<int> ID_SUBSTITUIDO { get; set; }
        public int STATUS { get; set; }
        public Nullable<int> ENVIADO { get; set; }
        public Nullable<System.DateTime> DATA_ENVIO { get; set; }
        public string BOARD_PASS { get; set; }
        public string CODIGO_IBGE_ORIGEM { get; set; }
        public string CODIGO_IBGE_DESTINO { get; set; }
        public Nullable<System.DateTime> DATA_HORA_VIAGEM { get; set; }
        public Nullable<bool> VENDA_ATUALIZADA { get; set; }
        public Nullable<int> STATUS_PROCESSO_SEFAZ { get; set; }
    
        public virtual BPE_CONFIGURACAO_EMITENTE BPE_CONFIGURACAO_EMITENTE { get; set; }
    }
}
