using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RssReader.DataAccessLayer.Interfaces;
namespace RssReader.Web.Models
{
    public class MakeTableViewModel
    {
        public IEnumerable<IPublication> Publications { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SelectSource { get; set; }
        public string KindOfSorting { get; set; }
    }
}