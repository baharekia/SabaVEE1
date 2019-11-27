
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

            List<object> PreFinalReadOutList = ReadOutList;

            // this is our final readout list after reducing the main list and what remains is ordered list just by one reaout data in every month
            List<object> FinalReadOutList = new List<object>();

            DateTime tempTime1 = new DateTime();
            DateTime temptime2 = new DateTime();

            var ctt = new CreateTempTime();
            DateTime lastReadOutDate = new DateTime();

            foreach (object[] element in PreFinalReadOutList)
            {
                if (element[0] != null)
                {
                    DateTime convertedDate = shamsiDate.DateConvertor(element);

                    tempTime1 = ctt.CreateTime(convertedDate);

                    if(tempTime1 == temptime2 && lastReadOutDate == convertedDate)
                    {
                        element[0] = convertedDate;
                        
                        FinalReadOutList.Add(element);
                    }

                    if(temptime2 != tempTime1)
                    {
                        temptime2 = tempTime1;
                        element[0] = convertedDate;
                        FinalReadOutList.Add(element);
                        lastReadOutDate = convertedDate;
                    }
                }
            }

            // Create Ordered ReadOutList
            List<object> FinalOrderedReadOutList = new List<object>();
            int m = 0;

            DateTime cmdate = new DateTime();

            object[] asb = (object[])FinalReadOutList.FirstOrDefault();
            cmdate = (DateTime)asb[0];

            int tm = 0;
            int ym = 0;
            int dm = 0;

            foreach (object[] element in FinalReadOutList)
            {
                if (cmdate != (DateTime)element[0])
                {
                    DateTime d = (DateTime)element[0];

                    tm = d.Month;
                    ym = d.Year;
                    dm = d.Day;
                    cmdate = (DateTime)element[0];
                    m = 0;
                }

                if (element[2] != null && element[2].ToString().Contains("802010000") && element[2].ToString()!= ("0802010000FF"))
                {
                    if (dm > 20 && dm <= 31)
                    {
                        if (tm < 1)
                        {
                            tm = 12;
                            ym = ym - 1;
                            element[5] = ym.ToString() + "." + tm.ToString();
                            tm = tm - 1;
                        }
                        else
                        {
                            element[5] = ym.ToString() + "." + tm.ToString();
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
                            element[5] = ym.ToString() + "." + (tm).ToString();

                        }
                        else
                        {
                            element[5] = ym.ToString() + "." + (tm).ToString();
                        }
                    }

                    m++;
                    FinalOrderedReadOutList.Add(element);
                }

                if (element[2] != null && element[2].ToString().Contains("802606202"))
                {
                    FinalOrderedReadOutList.Add(element);
                }
            }

            List<object> ReadOutList1 = new List<object>();
            List<object> ReadOutList2 = new List<object>();

            int ii = 1;
            foreach (object[] obj in FinalOrderedReadOutList)
            {
                int jj = 1;
                foreach (object drv in obj)
                {
                    xlWorkSheet.Cells[ii, jj] = drv;
                    jj++;
                }
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


