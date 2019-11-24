using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class Shamsi_to_Miladi_convertorDate
    {
        PersianCalendar pc = new PersianCalendar();

        public DateTime DateConvertor(int year, int month, int day)
        {
            return new DateTime(year, month, day, pc);
        }

        //Console.WriteLine(dt.ToString(CultureInfo.InvariantCulture));
    }
}
