using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration.Conventions;

namespace LTIPCM.Model
{
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("DateTime2").HasPrecision(0));
        }

    }

}
