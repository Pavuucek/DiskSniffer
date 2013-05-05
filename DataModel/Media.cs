using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSniffer.DataModel
{
    public class Media
    {
        public long MediaId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public MediaType Type { get; set; }

        public virtual ICollection<MediaFile> MediaFiles { get; set; }

        public Media()
        {
            Created = DateTime.Now;
        }
    }
}
