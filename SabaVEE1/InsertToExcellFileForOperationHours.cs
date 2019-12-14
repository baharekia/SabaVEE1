
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

            List<AnalysisDataModel> myList = new List<AnalysisDataModel>();
            var lastItem = FinalOrderedReadOutList.FirstOrDefault();
            int index = 0;

            column = 1;
            foreach (AnalysisDataModel item in FinalOrderedReadOutList)
            {
                if (lastItem.ReadOutDate == item.ReadOutDate)
                {
                    myList.Add(item);
                }

                else
                {
                    row = row + 7;
                    foreach (AnalysisDataModel itemm in myList)
                    {

                        xlWorkSheet.Cells[row++, column].Value = itemm.ReadOutDate;

                        xlWorkSheet.Cells[row++, column].Value = itemm.TransferDate;

                        xlWorkSheet.Cells[row++, column].Value = itemm.Obis;

                        xlWorkSheet.Cells[row++, column].Value = itemm.Value;

                        xlWorkSheet.Cells[row++, column].Value = itemm.ObisFarciDesc;

                        xlWorkSheet.Cells[row, column++].Value = itemm.Date;

                        row = row - 5;
                    }
                    myList.Clear();
                    myList.Add(item);
                    lastItem = item;
                    column = 1;
                }
            }

            row = row + 7;
            foreach (AnalysisDataModel itemmm in myList)
            {

                xlWorkSheet.Cells[row++, column].Value = itemmm.ReadOutDate;

                xlWorkSheet.Cells[row++, column].Value = itemmm.TransferDate;

                xlWorkSheet.Cells[row++, column].Value = itemmm.Obis;

                xlWorkSheet.Cells[row++, column].Value = itemmm.Value;

                xlWorkSheet.Cells[row++, column].Value = itemmm.ObisFarciDesc;

                xlWorkSheet.Cells[row, column++].Value = itemmm.Date;

                row = row - 5;
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
