using RssReader.BusinessLogicLayer.Infrastructure;
using RssReader.DataAccessLayer.Entities;
using RssReader.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RssReader.BusinessLogicLayer.Interfaces
{
    public interface IPublicationService:IDisposable
    { 
        void ParseRssFeeds();
        IEnumerable<IPublication> GetAllPublications ();
        List<string> UrlList { get; }
        IPublication FirstOrDefault(Func<IPublication, bool> predicate);
        IEnumerable<IPublication> Find(Func<IPublication, bool> predicate);
        Dictionary<string, SourceInfo> SourceInfoList { get; }     
    }
}
