using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.BusinessLogicLayer.Infrastructure
{
    public class SourceInfo
    {
        public SourceInfo()
        {
            this.SavedPublicationСount = 0;
            this.ReadedPublicationСount = 0;
        }

        public int SavedPublicationСount { get; set; }
        public int ReadedPublicationСount { get; set; }
    }
}
