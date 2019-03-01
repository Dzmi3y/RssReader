using RssReader.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DataAccessLayer.Interfaces
{
   public interface IPublicationRepository:IDisposable
    {
        void AddPublication(IPublication newPublications);
        IEnumerable<IPublication> GetAll();
        IEnumerable<IPublication> Find(Func<IPublication, bool> predicate);
        IPublication FirstOrDefault(Func<IPublication, bool> predicate);
        void Save();
    }
}
