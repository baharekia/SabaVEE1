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
        //SqlConnection cnn;
        //string connectionString = null;
        //string sql = null;
        //int i = 0;
        //int j = 0;
        //string data = null;
        List<PreAnalysisDataModel> ReadOutList = new List<PreAnalysisDataModel>();

        public List<PreAnalysisDataModel> GetReadOutDataFromSqlServerMethod(string MeterNumber)
        {
            SabaCandHEntities2 context = new SabaCandHEntities2();

            var ss = context.Meters.
                Join(context.OBISValueHeaders, a => a.MeterID, b => b.MeterID,
                (a, b) => new { a, b }).
                Join(context.OBISValueDetails, c => c.b.OBISValueHeaderID, d => d.OBISValueHeaderID,
                (c, d) => new { c, d }).
                Join(context.OBISSes, e => e.d.OBISID, g => g.OBISID,
                (e, g) => new { e, g }).
                Where(f => f.e.c.a.MeterNumber == MeterNumber && f.e.d.Value != "0" && (f.e.d.OBISID == 83 || f.g.ObisFarsiDesc.Contains("آب مصرفي کل") || f.e.d.OBISID == 88 || f.g.ObisFarsiDesc.Contains("ساعت"))).
                //OrderBy(h => h.e.c.b.ReadDate).
                //ThenBy(j => j.g.Obis).
                Select(f => new PreAnalysisDataModel
                {
                    Obis = f.g.Obis,
                    ReadOutDate = f.e.c.b.ReadDate,
                    TransferDate = f.e.c.b.TransferDate,
                    ObisFarciDesc = f.g.ObisFarsiDesc,
                    Date = "",
                    Value = f.e.d.Value
                }).Distinct().OrderBy(x=>x.ReadOutDate).ThenBy(x=> x.Obis).ToList();

            return ss;


            //var ReadOutList = (from meter in context.Meters
            //                   join oBISValueHeader in context.OBISValueHeaders on meter.MeterID equals oBISValueHeader.MeterID
            //                   join oBISValueDetails in context.OBISValueDetails on oBISValueHeader.OBISValueHeaderID equals oBISValueDetails.OBISValueHeaderID
            //                   join oBISS in context.OBISSes on oBISValueDetails.OBISID equals oBISS.OBISID
            //                   where meter.MeterNumber == MeterNumber //&& oBISValueDetails.Value != "0" && (oBISS.OBISID == 83 || oBISS.ObisFarsiDesc.Contains("آب مصرفي کل") || oBISS.OBISID == 88 || oBISS.ObisFarsiDesc.Contains("ساعت"))

            //                   orderby oBISValueHeader.ReadDate, oBISS.Obis

            //                   select new PreAnalysisDataModel()
            //                   {
            //                       ReadOutDate = oBISValueHeader.ReadDate,
            //                       TransferDate = oBISValueHeader.TransferDate,
            //                       Obis = oBISS.Obis,
            //                       Value = oBISValueDetails.Value,
            //                       ObisFarciDesc = oBISS.ObisFarsiDesc,
            //                       Date = ""
            //                   }).Distinct().ToList();


            //return ReadOutList;

            //connectionString = "Data Source=.;Initial Catalog=SabaCandH;User ID=sa;Password=88102351-7";
            //cnn = new SqlConnection(connectionString);
            //cnn.Open();
            //sql = "select distinct ReadDate,TransferDate,obis,Value,ObisFarsiDesc from Meter inner join OBISValueHeader on meter.MeterID = OBISValueHeader.MeterID inner join OBISValueDetail on OBISValueDetail.OBISValueHeaderID = OBISValueHeader.OBISValueHeaderID inner join OBISS on obiss.OBISID = OBISValueDetail.OBISID where Meter.MeterNumber ='"+MeterNumber+"' and Value != '0'and(Obiss.OBISID = 83 or ObisFarsiDesc like '%آب مصرفي کل%' or Obiss.OBISID = 88 or ObisFarsiDesc like '%ساعت%') order by ReadDate,OBISS.Obis";
            //SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            //DataSet ds = new DataSet();

            //dscmd.Fill(ds);
            //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //{
            //    object[] dataEntryArray = new object[6];

            //    for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            //    {
            //        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();

            //        dataEntryArray[j] = data;
            //    }
            //    ReadOutList.Add(dataEntryArray);
            //}
            //return ReadOutList;
        }
    }
}
