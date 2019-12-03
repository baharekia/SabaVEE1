
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class InsertToExcellFileForOperationHours
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;

        public void InsertToExcellFileMethod(List<AnalysisDataModel> ReadOutListNew, List<AnalysisDataModel> FinalOrderedReadOutList)
        {
            int row = 2;
            int column = 1;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            foreach (AnalysisDataModel item in ReadOutListNew)
            {
                column = 1;
                xlWorkSheet.Cells[row, column++].Value = item.ReadOutDate;
                xlWorkSheet.Cells[row, column++].Value = item.Value;
                xlWorkSheet.Cells[row++, column].Value = item.Date;
            }

            xlWorkSheet.Cells[row++, column].Value = "";

            xlWorkSheet.Cells[row, 1].Value = "ReadDate";
            xlWorkSheet.Cells[row, 2].Value = "TransferDate";
            xlWorkSheet.Cells[row, 3].Value = "Obis";
            xlWorkSheet.Cells[row, 4].Value = "Value";
            xlWorkSheet.Cells[row, 5].Value = "ObisFarciDesc";
            xlWorkSheet.Cells[row++, 6].Value = "Date";
            foreach (AnalysisDataModel item in FinalOrderedReadOutList)
            {
                column = 1;
                xlWorkSheet.Cells[row, column++].Value = item.ReadOutDate;
                xlWorkSheet.Cells[row, column++].Value = item.TransferDate;
                xlWorkSheet.Cells[row, column++].Value = item.Obis;
                xlWorkSheet.Cells[row, column++].Value = item.Value;
                xlWorkSheet.Cells[row, column++].Value = item.ObisFarciDesc;
                xlWorkSheet.Cells[row++, column].Value = item.Date;

            }

            xlWorkBook.SaveAs(@"D:\TotalOperationHoursAnalysis.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            var a = new aaa();
            a.releaseObject(xlWorkSheet);
            a.releaseObject(xlWorkBook);
            a.releaseObject(xlApp);

        }
    }
}
