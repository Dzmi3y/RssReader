using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.BusinessLogicLayer.Interfaces;
using RssReader.BusinessLogicLayer.Services;
using RssReader.BusinessLogicLayer.Infrastructure;
namespace RssReader.ConsoleApp
{
    class ConsoleManager
    {
        IPublicationServiceCreator ServiceCreator;
        IPublicationService PubServ;
        public ConsoleManager()
        {
            ServiceCreator = new PublicationServiceCreator();
            PubServ = ServiceCreator.ServiceCreator("DefaultConnection", new List<string> { "https://habr.com/ru/rss/all/all/", "https://rss.interfax.by/if_news_belarus.rss" });

        }

        public void LoadRss()
        {
            PubServ.ParseRssFeeds();
        }

        public List<string> GetInfo()
        {
            List<string> result = new List<string>();
            foreach (var item in PubServ.SourceInfoList)
            {
                string newString;
                newString = "Source: "+item.Key;
                newString += " Read: "+item.Value.ReadedPublicationСount;
                newString += " Save: "+item.Value.SavedPublicationСount;
                result.Add(newString);
            }
            return result;
        }

    }
}
