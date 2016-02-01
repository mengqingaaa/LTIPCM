using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTIPCM.Model
{
    public class Client : ICloneable
    {
        public int ClientID { get; set; }

        public string NameEng { get; set; }
        public string NameChn { get; set; }

        public string Address1Eng { get; set; }
        public string Address2Eng { get; set; }

        public string Address1Chn { get; set; }
        public string Address2Chn { get; set; }

        public string Zip { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? LastModifyTime { get; set; }

        public bool? Enable { get; set; }

        /// <summary>
        /// Navigation Property
        /// </summary>
        public virtual ICollection<Case> Cases { get; set; }

        public object Clone()
        {
            Client cloneClient = (Client)this.MemberwiseClone();

            if (this.CreateTime == null)
                cloneClient.CreateTime = null;
            else
                cloneClient.CreateTime = DateTime.Parse(this.CreateTime.ToString());

            if (this.LastModifyTime == null)
                cloneClient.LastModifyTime = null;
            else
                cloneClient.LastModifyTime = DateTime.Parse(this.LastModifyTime.ToString());

            return cloneClient;
        }

    }
}
