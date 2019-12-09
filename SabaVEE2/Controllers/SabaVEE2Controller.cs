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
        [Route("GetMeterNumberForWaterConsumption/{MeterNumber}")]
        public IHttpActionResult GetMeterNumberForWaterConsumption(string MeterNumber)
        {
            List<PreAnalysisDataModel> ReadOutList = new List<PreAnalysisDataModel>();

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServer = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServer.GetReadOutDataFromSqlServerMethod(MeterNumber);

            EntryPontForWaterDataAnalysis entryPontForWaterDataAnalysis = new EntryPontForWaterDataAnalysis();
            entryPontForWaterDataAnalysis.EntryPontForWaterDataAnalysisMethod(ReadOutList);

            return Ok("Total Water Consumption Data Analysis Calculated");
        }

        [Route("GetMeterNumberForOperationHours/{MeterNumber}")]
        public IHttpActionResult GetMeterNumberForOperationHours(string MeterNumber)
        {
            List<PreAnalysisDataModel> ReadOutList = new List<PreAnalysisDataModel>();

            GetReadOutDataFromSqlServer getReadOutDataFromSqlServerr = new GetReadOutDataFromSqlServer();
            ReadOutList = getReadOutDataFromSqlServerr.GetReadOutDataFromSqlServerMethod(MeterNumber);

            EntryPontForOperationHoursataAnalysis entryPontForOperationHoursataAnalysis = new EntryPontForOperationHoursataAnalysis();
            entryPontForOperationHoursataAnalysis.EntryPontForOperationHoursataAnalysisMethod(ReadOutList);

            return Ok("Total Operation Hoirs Data Analysis Calculated");
        }
    }
}
