using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSniffer.DataModel
{
    public class DataContext : DbContext
    {
        public DbSet<Media> Mediae { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }

    }
}
