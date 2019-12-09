using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class WaterConsumptionDataAnalysis
    {
        public void WaterConsumptionDataAnalysisMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            #region Total Water Consumption 
            
            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNew = new List<AnalysisDataModel>();

            CreateNewListWithDataModel createNewListWithDataModel = new CreateNewListWithDataModel();
            FinalReadOutList = createNewListWithDataModel.CreateNewListWithDataModelMethod(ReadOutList);

            AddModifiedDateColumnToReadOutListForWaterConsumption addModifiedDateColumnToReadOutList = new AddModifiedDateColumnToReadOutListForWaterConsumption();
            FinalOrderedReadOutList = addModifiedDateColumnToReadOutList.AddModifiedDateColumnToReadOutListMethod(FinalReadOutList);

            CreateFinalList createFinalList = new CreateFinalList();
            ReadOutListNew = createFinalList.CreateFinalListMethod(FinalOrderedReadOutList);

            InsertToExcellFileForWaterConsumption InsertToExcellFile = new InsertToExcellFileForWaterConsumption();
            InsertToExcellFile.InsertToExcellFileMethod(ReadOutListNew, FinalOrderedReadOutList);
            #endregion
        }
    }
}
