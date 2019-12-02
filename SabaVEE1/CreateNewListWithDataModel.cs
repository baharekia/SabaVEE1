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

        public List<AnalysisDataModel>  CreateNewListWithDataModelMethod(List<object> ReadOutList)
        {
            foreach (object[] element in ReadOutList)
            {
                if (element[0] != null)
                {
                    DateTime convertedDate = shamsiDate.DateConvertor(element);
                    AnalysisDataModel analysisData = new AnalysisDataModel();

                    tempTime1 = ctt.CreateTime(convertedDate);

                    if (tempTime1 == temptime2 && lastReadOutDate == convertedDate)
                    {
                        element[0] = convertedDate;
                        analysisData = new AnalysisDataModel((DateTime)element[0],
                            element[1].ToString(),
                            element[2].ToString(),
                            element[3].ToString(),
                            element[4].ToString(),
                            "");
                        FinalReadOutList.Add(analysisData);
                    }

                    if (temptime2 != tempTime1)
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
            return FinalReadOutList;
        }
    }
}
