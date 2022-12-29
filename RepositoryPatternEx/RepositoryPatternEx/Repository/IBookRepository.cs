using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternEx.Models;

namespace RepositoryPatternEx.Repository
{
    interface IBookRepository 
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int id);
        void InsertBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);
        void Save();
    }
}
