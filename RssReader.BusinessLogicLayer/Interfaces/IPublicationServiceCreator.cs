using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.DataAccessLayer.Interfaces;

namespace RssReader.BusinessLogicLayer.Interfaces
{
    public interface IPublicationServiceCreator
    {
        IPublicationService ServiceCreator(string connection, List<string> urls);
    }
}
