using Common;
using SabaVEE1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SabaVEE2.Controllers
{
    public class SabaVEE2Controller : ApiController
    {
        [Route("GetMeterNumber/{MeterNumber}")]
        public List<FinalPresentationDataModel> GetMeterNumberForWaterConsumption(string MeterNumber)
        {
            List<PreAnalysisDataModel> ReadOutList = new List<PreAnalysisDataModel>();
            List<FinalPresentationDataModel> FinalReturnedList = new List<FinalPresentationDataModel>();

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServer = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServer.GetReadOutDataFromSqlServerMethod(MeterNumber);

            EntryPonitForDataAnalysis entryPontForWaterDataAnalysis = new EntryPonitForDataAnalysis();
            FinalReturnedList =  entryPontForWaterDataAnalysis.EntryPonitForDataAnalysisMethod(ReadOutList);

            return FinalReturnedList;
        }
    }
}
