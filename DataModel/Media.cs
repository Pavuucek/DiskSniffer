using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSniffer.DataModel
{
    public class Media
    {
        /// <summary>
        /// 
        /// </summary>
        public long MediumId { get; set; }

        public DateTime Created { get; set; }
        public MediaType Type { get; set; }

        public virtual ICollection<MediaFile> MediaFiles { get; set; }

    }
}
