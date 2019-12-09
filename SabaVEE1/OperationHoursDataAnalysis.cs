using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class OperationHoursDataAnalysis
    {
        public void OperationHoursDataAnalysisMethod(List<PreAnalysisDataModel> ReadOutListt)
        {
            #region Total Operation Hours
            List<AnalysisDataModel> FinalReadOutListt = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutListt = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNeww = new List<AnalysisDataModel>();

            CreateNewListWithDataModel createNewListWithDataModell = new CreateNewListWithDataModel();
            FinalReadOutListt = createNewListWithDataModell.CreateNewListWithDataModelMethod(ReadOutListt);

            AddModifiedDateColumnToReadOutListForOperationHours addModifiedDateColumnToReadOutListt = new AddModifiedDateColumnToReadOutListForOperationHours();
            FinalOrderedReadOutListt = addModifiedDateColumnToReadOutListt.AddModifiedDateColumnToReadOutListMethod(FinalReadOutListt);

            CreateFinalList createFinalListt = new CreateFinalList();
            ReadOutListNeww = createFinalListt.CreateFinalListMethod(FinalOrderedReadOutListt);

            InsertToExcellFileForOperationHours InsertToExcellFilee = new InsertToExcellFileForOperationHours();
            InsertToExcellFilee.InsertToExcellFileMethod(ReadOutListNeww, FinalOrderedReadOutListt);
            #endregion
        }
    }
}
