using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class EntryPontForWaterDataAnalysis
    {
        public void EntryPontForWaterDataAnalysisMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            WaterConsumptionDataAnalysis waterConsumptionDataAnalysis = new WaterConsumptionDataAnalysis();
            waterConsumptionDataAnalysis.WaterConsumptionDataAnalysisMethod(ReadOutList);
        }
    }
}
