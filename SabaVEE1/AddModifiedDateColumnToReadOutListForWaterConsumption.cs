
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class AddModifiedDateColumnToReadOutListForWaterConsumption
    {
        List<AnalysisDataModel> FinalOrderedReadOutList = new List<AnalysisDataModel>();
        public List<AnalysisDataModel> AddModifiedDateColumnToReadOutListMethod(List<AnalysisDataModel> FinalReadOutList)
        {
            int m = 0;

            DateTime cmdate = new DateTime();

            AnalysisDataModel asb = FinalReadOutList.FirstOrDefault();
            AnalysisDataModel lastItemInThisList = new AnalysisDataModel(new DateTime(), "", "", "", "", "");
            cmdate = asb.ReadOutDate;

            int tm = cmdate.Month;
            int ym = cmdate.Year;
            int dm = cmdate.Day;

            foreach (AnalysisDataModel element in FinalReadOutList)
            {
                if (cmdate != element.ReadOutDate)
                {
                    DateTime d = element.ReadOutDate;

                    tm = d.Month;
                    ym = d.Year;
                    dm = d.Day;
                    cmdate = element.ReadOutDate;
                    m = 0;
                }

                if (element.Obis != null && element.Obis.Contains("802010000") && element.Obis != ("0802010000FF"))
                {

                    if (dm >= 20 && dm <= 31)
                    {
                        if (tm < 1)
                        {
                            tm = 12;
                            ym = ym - 1;
                            element.Date = ym.ToString() + "." + tm.ToString();
                            tm = tm - 1;
                        }
                        else
                        {
                            element.Date = ym.ToString() + "." + tm.ToString();
                            tm = tm - 1;
                        }
                    }

                    else
                    {
                        tm = tm - 1;
                        if (tm < 1)
                        {
                            tm = 12;
                            ym = ym - 1;
                            element.Date = ym.ToString() + "." + (tm).ToString();

                        }
                        else
                        {
                            element.Date = ym.ToString() + "." + (tm).ToString();
                        }
                    }

                    m++;
                    if (lastItemInThisList.ObisFarciDesc != element.ObisFarciDesc)
                    {
                        FinalOrderedReadOutList.Add(element);
                        lastItemInThisList = FinalOrderedReadOutList.LastOrDefault();
                    }
                    else
                    {
                        tm = tm + 1;
                    }
                }

                //if (element[2] != null && element[2].ToString().Contains("802606202"))
                //{
                //    FinalOrderedReadOutList.Add(element);
                //}
            }
            return FinalOrderedReadOutList;
        }
    }
}
