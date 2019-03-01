using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.BusinessLogicLayer.Infrastructure;
using RssReader.BusinessLogicLayer.Interfaces;
using RssReader.DataAccessLayer.Entities;
using RssReader.DataAccessLayer.Interfaces;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssReader.BusinessLogicLayer.Services
{
    public class PublicationService : IPublicationService
    {
        private IPublicationRepository database;

        public List<string> UrlList { get; private set; }

        public Dictionary<string, SourceInfo> SourceInfoList { get; private set; }

        public PublicationService(IPublicationRepository repository, List<string> urlList)
        {
            this.database = repository;
            this.UrlList = urlList;
            SourceInfoList = new Dictionary<string, SourceInfo>();
        }

        public IPublication FirstOrDefault(Func<IPublication, bool> predicate)
        {
            return database.FirstOrDefault(predicate);
        }

        public IEnumerable<IPublication> Find(Func<IPublication, bool> predicate)
        {
            return database.Find(predicate);
        }

        public IEnumerable<IPublication> GetAllPublications()
        {
            return database.GetAll();
        }


        public void ParseRssFeeds()
        {
            SourceInfoList.Clear();

            foreach (string currentUrl in UrlList)
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(currentUrl));

                foreach (SyndicationItem feedItem in feed.Items)
                {
                    ProcessingOneElementOfFeeds(currentUrl, feedItem);
                }
            }

            database.Save();
        }

        private void ProcessingOneElementOfFeeds(string currentUrl, SyndicationItem feedItem)
        {

            Func<IPublication, bool> predicate = p => (p.PublicationDate == feedItem.PublishDate.DateTime) && (p.Title == feedItem.Title.Text);
            IPublication currentPublication = database.FirstOrDefault(predicate);

            if (!SourceInfoList.ContainsKey(currentUrl))
            {
                SourceInfoList.Add(currentUrl, new SourceInfo());
            }

            SourceInfoList[currentUrl].ReadedPublicationСount++;

            if (currentPublication == null)
            {
                IPublication newPublication =
                    new Publication
                    {
                        Title = feedItem.Title.Text,
                        Description = feedItem.Summary.Text,
                        Link = feedItem.Id,
                        PublicationDate = feedItem.PublishDate.DateTime,
                        Source = currentUrl
                    };

                database.AddPublication(newPublication);
                SourceInfoList[currentUrl].SavedPublicationСount++;
            }
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
