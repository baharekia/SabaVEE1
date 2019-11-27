
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

namespace SabaVEE1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            
            int i = 0;
            int j = 0;
            
            DateTime date95 = new DateTime(1395, 01, 01);
            
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
            sql = "select distinct ReadDate,TransferDate,obis,Value,ObisFarsiDesc from Meter inner join OBISValueHeader on meter.MeterID = OBISValueHeader.MeterID inner join OBISValueDetail on OBISValueDetail.OBISValueHeaderID = OBISValueHeader.OBISValueHeaderID inner join OBISS on obiss.OBISID = OBISValueDetail.OBISID where Meter.MeterNumber = '1949400024668' and Value != '0'and(Obiss.OBISID = 83 or ObisFarsiDesc like '%آب مصرفي کل%' or Obiss.OBISID = 88 or ObisFarsiDesc like '%ساعت%') order by ReadDate,OBISS.Obis";

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            List<object> ReadOutList = new List<object>();
            
            // Create PreFinalReadOutList
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                object[] dataEntryArray = new object[6];

                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    
                    dataEntryArray[j] = data;
                }
                ReadOutList.Add(dataEntryArray);
            }

            List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();

            DateTime tempTime1 = new DateTime();
            DateTime temptime2 = new DateTime();

            var ctt = new CreateTempTime();
            DateTime lastReadOutDate = new DateTime();

            foreach (object[] element in ReadOutList)
            {
                if (element[0] != null)
                {
                    DateTime convertedDate = shamsiDate.DateConvertor(element);
                    AnalysisDataModel analysisData = new AnalysisDataModel();

                    tempTime1 = ctt.CreateTime(convertedDate);

                    if(tempTime1 == temptime2 && lastReadOutDate == convertedDate)
                    {
                        element[0] = convertedDate;
                        analysisData= new AnalysisDataModel((DateTime)element[0],
                            element[1].ToString(),
                            element[2].ToString(),
                            element[3].ToString(), 
                            element[4].ToString(), 
                            "");
                        FinalReadOutList.Add(analysisData);
                    }

                    if(temptime2 != tempTime1)
                    {
                        temptime2 = tempTime1;
                        element[0] = convertedDate;
                        analysisData = new AnalysisDataModel((DateTime)element[0],
                            element[1].ToString(),
                            element[2].ToString(),
                            element[3].ToString(),
                            element[4].ToString(),
                            "");
                        FinalReadOutList.Add(analysisData);
                        lastReadOutDate = convertedDate;
                    }
                }
            }

            // Create Ordered ReadOutList
            List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
            int m = 0;

            DateTime cmdate = new DateTime();

            AnalysisDataModel asb = FinalReadOutList.FirstOrDefault();
            cmdate = asb.ReadOutDate;

            int tm = 0;
            int ym = 0;
            int dm = 0;

            foreach (AnalysisDataModel element in FinalReadOutList)
            {
                if (cmdate != element.ReadOutDate)
                {
                    DateTime d = element.ReadOutDate;

                    tm = d.Month;
                    ym = d.Year;
                    dm = d.Day;
                    cmdate = element.ReadOutDate;
                    m = 0;
                }

                if (element.Obis != null && element.Obis.Contains("802010000") && element.Obis!= ("0802010000FF"))
                {
                    if (dm > 20 && dm <= 31)
                    {
                        if (tm < 1)
                        {
                            tm = 12;
                            ym = ym - 1;
                            element.Date = ym.ToString() + "." + tm.ToString();
                            tm = tm - 1;
                        }
                        else
                        {
                            element.Date = ym.ToString() + "." + tm.ToString();
                            tm = tm - 1;
                        }
                    }

                    else
                    {
                        tm = tm - 1;
                        if (tm < 1)
                        {
                            tm = 12;
                            ym = ym - 1;
                            element.Date = ym.ToString() + "." + (tm).ToString();

                        }
                        else
                        {
                            element.Date = ym.ToString() + "." + (tm).ToString();
                        }
                    }

                    m++;
                    FinalOrderedReadOutList.Add(element);
                }

                //Not consider SatKarkard
                //if (element[2] != null && element[2].ToString().Contains("802606202"))
                //{
                //    FinalOrderedReadOutList.Add(element);
                //}
            }

            List<object> ReadOutList1 = new List<object>();

            List<object> ReadOutList2 = new List<object>();

            DateTime oldReadOuteDate = new DateTime();

            AnalysisDataModel mnl = FinalOrderedReadOutList.FirstOrDefault();
            oldReadOuteDate = mnl.ReadOutDate;

            object newItem = null;

            //foreach (object[] element in FinalOrderedReadOutList)
            //{
            //    if (oldReadOuteDate[0] != element[0])
            //    {
            //        oldItem = element;
            //    }
            //}


            int ii = 1;
            foreach (AnalysisDataModel obj in FinalOrderedReadOutList)
            {
                xlWorkSheet.Cells[ii] = obj;
                ii++;
            }

            xlWorkBook.SaveAs(@"D:\Excellproject.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);                   
            xlApp.Quit();

            var a = new aaa();
            a.releaseObject(xlWorkSheet);
            a.releaseObject(xlWorkBook);
            a.releaseObject(xlApp);

        }
    }
}


