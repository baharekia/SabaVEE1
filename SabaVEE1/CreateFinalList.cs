using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{

    public class CreateFinalList
    {
        List<AnalysisDataModel> ReadOutListOld = new List<AnalysisDataModel>();
        List<AnalysisDataModel> ReadOutListNew = new List<AnalysisDataModel>();
        List<AnalysisDataModel> ReversReadOutListNew = new List<AnalysisDataModel>();
        int index = 1;
        AnalysisDataModel lastitem1 = new AnalysisDataModel();
        AnalysisDataModel lastitem2 = new AnalysisDataModel();
        List<AnalysisDataModel> SampleLastItem = new List<AnalysisDataModel>();
        List<AnalysisDataModel> FinalConcatList = new List<AnalysisDataModel>();
        public List<AnalysisDataModel> CreateFinalListMethod(List<AnalysisDataModel> FinalOrderedReadOutList)
        {
            AnalysisDataModel OldSampleData = FinalOrderedReadOutList.FirstOrDefault();
            foreach (AnalysisDataModel item in FinalOrderedReadOutList)
            {
                if (item.ReadOutDate != OldSampleData.ReadOutDate)
                {
                    if (item.Date == OldSampleData.Date)
                    {
                        if (item.Value == OldSampleData.Value)
                        {
                            foreach (AnalysisDataModel itemm in FinalOrderedReadOutList)
                            {
                                if (item.ReadOutDate == itemm.ReadOutDate)
                                {
                                    if (index == 1)
                                    {
                                        OldSampleData = itemm;
                                        index = 0;
                                        ReadOutListOld = ReadOutListNew.ToList();
                                        ReadOutListNew.Clear();
                                    }
                                    ReadOutListNew.Add(itemm);
                                }
                            }

                            ReadOutListNew.Reverse();
                            lastitem1 = ReadOutListNew.FirstOrDefault();
                            ReadOutListOld.Reverse();

                            foreach (AnalysisDataModel u in ReadOutListOld)
                            {
                                if (lastitem1.Date == u.Date)
                                {
                                    break;
                                }
                                if (lastitem1.Date != u.Date)
                                {
                                    SampleLastItem.Add(u);
                                }
                            }

                            ReadOutListNew = SampleLastItem.Concat(ReadOutListNew).ToList();
                            SampleLastItem.Clear();
                            ReadOutListNew.Reverse();
                            index = 1;
                        }
                    }
                }
            }
            return ReadOutListNew;
        }
    }
}
