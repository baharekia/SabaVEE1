
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
            #region prerequisite
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            
            var shamsiDate = new Shamsi_to_Miladi_convertorDate();

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            connectionString = "Data Source=.;Initial Catalog=SabaCandH;User ID=sa;Password=88102351-7";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "select distinct ReadDate,TransferDate,obis,Value,ObisFarsiDesc from Meter inner join OBISValueHeader on meter.MeterID = OBISValueHeader.MeterID inner join OBISValueDetail on OBISValueDetail.OBISValueHeaderID = OBISValueHeader.OBISValueHeaderID inner join OBISS on obiss.OBISID = OBISValueDetail.OBISID where Meter.MeterNumber = '1949400024728' and Value != '0'and(Obiss.OBISID = 83 or ObisFarsiDesc like '%آب مصرفي کل%' or Obiss.OBISID = 88 or ObisFarsiDesc like '%ساعت%') order by ReadDate,OBISS.Obis";
            
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            List<object> ReadOutList = new List<object>();
            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
            List<AnalysisDataModel> ReadOutListNew = new List<AnalysisDataModel>();
            #endregion

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServer = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServer.GetReadOutDataFromSqlServerMethod(ds);

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


