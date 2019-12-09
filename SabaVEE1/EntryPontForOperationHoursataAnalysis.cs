using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class EntryPontForOperationHoursataAnalysis
    {
        public void EntryPontForOperationHoursataAnalysisMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            OperationHoursDataAnalysis operationHoursDataAnalysis = new OperationHoursDataAnalysis();
            operationHoursDataAnalysis.OperationHoursDataAnalysisMethod(ReadOutList);
        }
    }
}
