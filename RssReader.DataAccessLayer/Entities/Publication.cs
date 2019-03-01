using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.DataAccessLayer.Interfaces;

namespace RssReader.DataAccessLayer.Entities
{
    public class Publication:IPublication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
