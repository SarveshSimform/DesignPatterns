using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPatternEx.Models;
using RepositoryPatternEx.Repository;

namespace RepositoryPatternEx.Content
{
    public class BookController : Controller
    {
       private IBookRepository bookRepository;  
       public BookController()  
    {
            BookContext db = new BookContext();
           this.bookRepository = new BookRepository(db);  
    }  
        public ActionResult Index()
        {
            var books = bookRepository.GetBooks(); 
            return View(books);
        }
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepository.InsertBook(book);
                    bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }
    }
}