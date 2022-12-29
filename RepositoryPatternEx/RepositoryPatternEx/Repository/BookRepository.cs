using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPatternEx.Models;
using System.Data.Entity;

namespace RepositoryPatternEx.Repository
{
    public class BookRepository : IBookRepository
    {
        BookContext context = new BookContext();
        public BookRepository(BookContext bookContext)
        {
            this.context = bookContext;
        }
        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }
        public Book GetBookByID(int id)
        {
            return context.Books.FirstOrDefault(x=> x.Id==id);
        }
        public void InsertBook(Book book)
        {
            context.Books.Add(book);
        }
        public void DeleteBook(int id)
        {
            Book book = context.Books.FirstOrDefault(x => x.Id == id);
            context.Books.Remove(book);
        }
        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}