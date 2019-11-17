using BpeCentral.Dominio.Comum.Enums;
using System;

namespace BpeCentral.Dominio.Comum.Request
{
    public class XmlBpeRequest
    {     
        private DateTime data { get; set; }
        public string Data {
            get
            {
                return data.Date.ToString();
            }
            set
            {
                data = Convert.ToDateTime(value);
            }
        }

        public DateTime GetData() { return data; }
    }
}
