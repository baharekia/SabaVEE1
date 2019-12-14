using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class WaterConsumptionAmdOperationHoursDataAnalysis
    {
        public List<FinalPresentationDataModel> WaterConsumptionAmdOperationHoursDataAnalysisMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> WaterFinalOrderedReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> OperationHoursFinalOrderedReadOutListt = new List<AnalysisDataModel>();
            List<AnalysisDataModel> WaterReadOutListNew = new List<AnalysisDataModel>();
            List<AnalysisDataModel> OperationReadOutListNew = new List<AnalysisDataModel>();
            List<FinalPresentationDataModel> returdedFinalList = new List<FinalPresentationDataModel>();

            CreateNewListWithDataModel createNewListWithDataModel = new CreateNewListWithDataModel();
          FinalReadOutList = createNewListWithDataModel.CreateNewListWithDataModelMethod(ReadOutList);

            AddModifiedDateColumnToReadOutListForWaterConsumption addModifiedDateColumnToReadOutListForWaterConsumption = new AddModifiedDateColumnToReadOutListForWaterConsumption();
            WaterFinalOrderedReadOutList = addModifiedDateColumnToReadOutListForWaterConsumption.AddModifiedDateColumnToReadOutListMethod(FinalReadOutList);

            AddModifiedDateColumnToReadOutListForOperationHours addModifiedDateColumnToReadOutListForOperationHours = new AddModifiedDateColumnToReadOutListForOperationHours();
            OperationHoursFinalOrderedReadOutListt = addModifiedDateColumnToReadOutListForOperationHours.AddModifiedDateColumnToReadOutListMethod(FinalReadOutList);

            CreateFinalList createFinalList = new CreateFinalList();
            CreateFinalList createFinalListt = new CreateFinalList();

            WaterReadOutListNew = createFinalList.CreateFinalListMethod(WaterFinalOrderedReadOutList);
            OperationReadOutListNew = createFinalListt.CreateFinalListMethod(OperationHoursFinalOrderedReadOutListt);

            CreateFinalNewList createFinalNewList = new CreateFinalNewList();
            returdedFinalList = createFinalNewList.CreateFinalNewListMethod(WaterReadOutListNew, OperationReadOutListNew);

            InsertToExcellFileForWaterConsumption InsertToExcellFile = new InsertToExcellFileForWaterConsumption();
            InsertToExcellFile.InsertToExcellFileMethod(WaterReadOutListNew, WaterFinalOrderedReadOutList);

            InsertToExcellFileForOperationHours InsertToExcellFileForOperationHours = new InsertToExcellFileForOperationHours();
            InsertToExcellFileForOperationHours.InsertToExcellFileMethod(OperationReadOutListNew, OperationHoursFinalOrderedReadOutListt);

            return returdedFinalList;
        }
    }
}
