using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RssReader.DataAccessLayer.Entities;


namespace RssReader.DataAccessLayer.EntityFramework
{
    public class DataContext:DbContext
    {
        public DataContext(string connectionString):base(connectionString)
        {
        }

        public DbSet<Publication> Publications { get; set; }
    }
}
