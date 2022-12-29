using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RepositoryPatternEx.Models
{
    public class BookContext : DbContext
    {
        public BookContext(): base("name=BookStoreConnectionString")
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}