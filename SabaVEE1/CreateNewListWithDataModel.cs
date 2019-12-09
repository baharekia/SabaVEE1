using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class CreateNewListWithDataModel
    {
        DateTime tempTime1 = new DateTime();
        DateTime temptime2 = new DateTime();
        Shamsi_to_Miladi_convertorDate shamsiDate = new Shamsi_to_Miladi_convertorDate();
        CreateTempTime ctt = new CreateTempTime();
        DateTime lastReadOutDate = new DateTime();
        List<AnalysisDataModel> FinalReadOutList = new List<AnalysisDataModel>();

        public List<AnalysisDataModel>  CreateNewListWithDataModelMethod(List<PreAnalysisDataModel> ReadOutList)
        {
            foreach (PreAnalysisDataModel element in ReadOutList)
            {
                if (element.ReadOutDate != null)
                {
                    DateTime convertedDate = shamsiDate.DateConvertor(element);
                    AnalysisDataModel analysisData = new AnalysisDataModel();

                    tempTime1 = ctt.CreateTime(convertedDate);

                    if (tempTime1 == temptime2 && lastReadOutDate == convertedDate)
                    {
                        analysisData = new AnalysisDataModel(convertedDate,
                            element.TransferDate.ToString(),
                            element.Obis.ToString(),
                            element.Value.ToString(),
                            element.ObisFarciDesc.ToString(),
                            "");
                        FinalReadOutList.Add(analysisData);
                    }

                    if (temptime2 != tempTime1)
                    {
                        temptime2 = tempTime1;
                        analysisData = new AnalysisDataModel(convertedDate,
                            element.TransferDate.ToString(),
                            element.Obis.ToString(),
                            element.Value.ToString(),
                            element.ObisFarciDesc.ToString(),
                            "");
                        FinalReadOutList.Add(analysisData);
                        lastReadOutDate = convertedDate;
                    }
                }
            }
            return FinalReadOutList;
        }
    }
}
