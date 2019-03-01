using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DataAccessLayer.Interfaces
{
    public interface IPublication
    {
         string Title { get; set; }
         string Source { get; set; }
         string Link { get; set; }
         string Description { get; set; }
         DateTime PublicationDate { get; set; }
    }
}
