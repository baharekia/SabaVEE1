
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;
using System.Globalization;

namespace SabaVEE1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shamsiDate = new Shamsi_to_Miladi_convertorDate(); 
            List<object> ReadOutList = new List<object>();
            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNew = new List<AnalysisDataModel>();

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServer = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServer.GetReadOutDataFromSqlServerMethod();

            CreateNewListWithDataModel createNewListWithDataModel = new CreateNewListWithDataModel();
            FinalReadOutList = createNewListWithDataModel.CreateNewListWithDataModelMethod(ReadOutList);

            AddModifiedDateColumnToReadOutList addModifiedDateColumnToReadOutList = new AddModifiedDateColumnToReadOutList();
            FinalOrderedReadOutList = addModifiedDateColumnToReadOutList.AddModifiedDateColumnToReadOutListMethod(FinalReadOutList);

            CreateFinalList createFinalList = new CreateFinalList();
            ReadOutListNew = createFinalList.CreateFinalListMethod(FinalOrderedReadOutList);

            InsertToExcellFile InsertToExcellFile = new InsertToExcellFile();
            InsertToExcellFile.InsertToExcellFileMethod(ReadOutListNew, FinalOrderedReadOutList);
        }
    }
}


