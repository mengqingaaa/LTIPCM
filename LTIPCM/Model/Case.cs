using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTIPCM.Model
{
    public class Case
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int CaseID { get; set; }

        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public int? ClientID { get; set; }

        /// <summary>
        /// Navigation Property
        /// </summary>
        public virtual Client Client { get; set; }
    }
}
