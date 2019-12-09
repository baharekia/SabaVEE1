using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PreAnalysisDataModel
    {
        public string ReadOutDate = null;
        public string TransferDate = null;
        public string Obis = null;
        public string Value = null;
        public string ObisFarciDesc = null;
        public string Date = "";

        public PreAnalysisDataModel()
        {

        }
        public PreAnalysisDataModel(string readOutDate, string transferDate, string obis, string value, string obisFarciDesc, string date)
        {
            this.ReadOutDate = readOutDate;
            this.TransferDate = transferDate;
            this.Obis = obis;
            this.Value = value;
            this.ObisFarciDesc = obisFarciDesc;
            this.Date = date;
        }
    }
}
