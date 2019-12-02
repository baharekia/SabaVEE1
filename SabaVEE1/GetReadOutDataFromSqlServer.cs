using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class GetReadOutDataFromSqlServer
    {
        SqlConnection cnn;
        string connectionString = null;
        string sql = null;
        int i = 0;
        int j = 0;
        string data = null;
        List<object> ReadOutList = new List<object>();

        public List<object> GetReadOutDataFromSqlServerMethod()
        {
            connectionString = "Data Source=.;Initial Catalog=SabaCandH;User ID=sa;Password=88102351-7";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "select distinct ReadDate,TransferDate,obis,Value,ObisFarsiDesc from Meter inner join OBISValueHeader on meter.MeterID = OBISValueHeader.MeterID inner join OBISValueDetail on OBISValueDetail.OBISValueHeaderID = OBISValueHeader.OBISValueHeaderID inner join OBISS on obiss.OBISID = OBISValueDetail.OBISID where Meter.MeterNumber = '1949400024728' and Value != '0'and(Obiss.OBISID = 83 or ObisFarsiDesc like '%آب مصرفي کل%' or Obiss.OBISID = 88 or ObisFarsiDesc like '%ساعت%') order by ReadDate,OBISS.Obis";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();

            dscmd.Fill(ds);
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
