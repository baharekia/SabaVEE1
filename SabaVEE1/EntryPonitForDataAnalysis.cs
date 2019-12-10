using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class EntryPonitForDataAnalysis
    {
        public List<FinalPresentationDataModel> EntryPonitForDataAnalysisMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            WaterConsumptionAmdOperationHoursDataAnalysis waterConsumptionAmdOperationHoursDataAnalysis = new WaterConsumptionAmdOperationHoursDataAnalysis();
            return waterConsumptionAmdOperationHoursDataAnalysis.WaterConsumptionAmdOperationHoursDataAnalysisMethod(ReadOutList);
        }
    }
}
