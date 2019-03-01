using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RssReader.BusinessLogicLayer.Interfaces;
using RssReader.BusinessLogicLayer.Services;
using RssReader.DataAccessLayer.Entities;
using RssReader.DataAccessLayer.Interfaces;
using RssReader.Web.Models;

namespace RssReader.Web.Controllers
{
    public class HomeController : Controller
    {
        IPublicationServiceCreator ServiceCreator;
        IPublicationService database;
        public HomeController()
        {
            ServiceCreator = new PublicationServiceCreator();
            database = ServiceCreator.ServiceCreator("DefaultConnection", new List<string> { "https://habr.com/ru/rss/all/all/", "https://rss.interfax.by/if_news_belarus.rss" });

        }

        public ActionResult Index()
        {
            return View(database.UrlList);
        }

       
        public ActionResult MakeTable(string selectSource, string kindOfSorting, int currentPage = 1)
        {
            IEnumerable<IPublication> selectedPublications = SelectionOfPublications(selectSource);

            IEnumerable<IPublication> sortedPublications = Sorting(kindOfSorting, selectedPublications);

            int pageSize = 10; 
            IEnumerable<IPublication> publicationPerPages = sortedPublications.Skip((currentPage - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = currentPage, PageSize = pageSize, TotalItems = sortedPublications.Count() };
            MakeTableViewModel result = new MakeTableViewModel { PageInfo = pageInfo, Publications = publicationPerPages, SelectSource = selectSource, KindOfSorting = kindOfSorting };

            return PartialView(result);
        }

        
        public ActionResult RenderPublicationsTable(IEnumerable<IPublication> publications)
        {

            return PartialView(publications);
        }

        private IEnumerable<IPublication> SelectionOfPublications(string selectSource)
        {
            IEnumerable<IPublication> selectedPublications;

            if (selectSource == "All")
            {
                selectedPublications = database.GetAllPublications();
            }
            else
            {
                Func<IPublication, bool> predicate = p => p.Source == selectSource;
                selectedPublications = database.Find(predicate);
            }

            return selectedPublications;
        }

        private static IEnumerable<IPublication> Sorting(string kindOfSorting, IEnumerable<IPublication> selectedPublications)
        {
            IEnumerable<IPublication> result;
            if (kindOfSorting == "bySource")
            {
                result = selectedPublications.OrderBy(p => p.Source);
            }
            else
            {
                result = selectedPublications.OrderBy(p => p.PublicationDate);
            }

            return result;
        }
    }
}