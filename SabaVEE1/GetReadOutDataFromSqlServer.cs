using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class GetReadOutDataFromSqlServer
    {
        int i = 0;
        int j = 0;
        string data = null;

        List<object> ReadOutList = new List<object>();

        public List<object> GetReadOutDataFromSqlServerMethod(DataSet ds)
        {
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
            return ReadOutList;
        }
    }
}
