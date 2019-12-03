
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
            #region Total Water Consumption 
            string MeterNumber = "";
            List<object> ReadOutList = new List<object>();
            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNew = new List<AnalysisDataModel>();
            Console.WriteLine("Please Enter MeterNumber :");
            MeterNumber = Console.ReadLine();
            GetReadOutDataFromSqlServer getReadOutDataFromSqlServer = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServer.GetReadOutDataFromSqlServerMethod(MeterNumber);

            CreateNewListWithDataModel createNewListWithDataModel = new CreateNewListWithDataModel();
            FinalReadOutList = createNewListWithDataModel.CreateNewListWithDataModelMethod(ReadOutList);

            AddModifiedDateColumnToReadOutListForWaterConsumption addModifiedDateColumnToReadOutList = new AddModifiedDateColumnToReadOutListForWaterConsumption();
            FinalOrderedReadOutList = addModifiedDateColumnToReadOutList.AddModifiedDateColumnToReadOutListMethod(FinalReadOutList);

            CreateFinalList createFinalList = new CreateFinalList();
            ReadOutListNew = createFinalList.CreateFinalListMethod(FinalOrderedReadOutList);

            InsertToExcellFileForWaterConsumption InsertToExcellFile = new InsertToExcellFileForWaterConsumption();
            InsertToExcellFile.InsertToExcellFileMethod(ReadOutListNew, FinalOrderedReadOutList);
            #endregion

            #region Total Operation Hours
            List<object> ReadOutListt = new List<object>();
            List<AnalysisDataModel> FinalReadOutListt = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutListt = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNeww = new List<AnalysisDataModel>();

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServerr = new GetReadOutDataFromSqlServer();
            ReadOutListt = getReadOutDataFromSqlServerr.GetReadOutDataFromSqlServerMethod(MeterNumber);

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


