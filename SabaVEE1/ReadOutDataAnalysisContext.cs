using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabaVEE1
{
    public class ReadOutDataAnalysisContext : DbContext
    {
        public ReadOutDataAnalysisContext() : base()
        {

        }

        public DbSet<AnalysisDataModel> Students { get; set; }
    }
}
