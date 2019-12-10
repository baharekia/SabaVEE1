using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class CreateFinalNewList
    {
        public List<FinalPresentationDataModel> CreateFinalNewListMethod(List<AnalysisDataModel> FinalWaterOrderedLisrt,List<AnalysisDataModel> FinalOperationOrderedList)
        {
            var result = FinalWaterOrderedLisrt.Join(FinalOperationOrderedList, arg => arg.Date, arg => arg.Date,
            (first, second) => new FinalPresentationDataModel { Date = first.Date, TotalConsumedWater = first.Value, TotalOperationHours = second.Value }).ToList() ;
            return result;
        }
    }
}
