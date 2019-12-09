﻿using System;
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

        public DateTime DateConvertor(PreAnalysisDataModel element )
        {
            char[] separator = { '/', '/', ' ' };

            var rd = element.ReadOutDate;
            String[] strlist = rd.Split(separator, 4);

            var year = Int32.Parse(strlist[0]);
            var month = Int32.Parse(strlist[1]);
            var day = Int32.Parse(strlist[2]);

            return new DateTime(year, month, day, pc);
        }

        //Console.WriteLine(dt.ToString(CultureInfo.InvariantCulture));
    }
}
