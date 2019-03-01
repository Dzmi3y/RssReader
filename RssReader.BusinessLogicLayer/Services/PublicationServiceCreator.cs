using RssReader.BusinessLogicLayer.Interfaces;
using RssReader.DataAccessLayer.Interfaces;
using RssReader.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.BusinessLogicLayer.Services
{
    public class PublicationServiceCreator : IPublicationServiceCreator
    {
        public IPublicationService ServiceCreator(string connection, List<string> urls)
        {
            return new PublicationService(new PublicationRepository(connection), urls);
        }
    }
}
