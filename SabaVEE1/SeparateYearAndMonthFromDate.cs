using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class SeparateYearAndMonthFromDate
    {
        public int[] SeparateYearAndMonthFromDateMethod(AnalysisDataModel u)
        {
            char separator = '.';
            string[] strlist = u.Date.Split(separator);
            return strlist.Select(int.Parse).ToArray();
        }
    }
}
