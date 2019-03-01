using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.DataAccessLayer.Entities;
using RssReader.DataAccessLayer.EntityFramework;
using RssReader.DataAccessLayer.Interfaces;


namespace RssReader.DataAccessLayer.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private DataContext database;

        public PublicationRepository(string stringConnection)
        {
            this.database = new DataContext(stringConnection);
        }

        public void AddPublication(IPublication newPublication)
        {
            database.Publications.Add(newPublication as Publication);
        }

        public void Save()
        {
            database.SaveChanges();
        }

        public IPublication FirstOrDefault(Func<IPublication, bool> predicate)
        {
            return database.Publications.FirstOrDefault(predicate);
        }

        public IEnumerable<IPublication> Find(Func<IPublication, bool> predicate)
        {
            return database.Publications.Where(predicate);
        }

        public IEnumerable<IPublication> GetAll()
        {
            return database.Publications.AsEnumerable();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
