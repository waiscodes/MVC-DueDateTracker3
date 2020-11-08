using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryDueDateTracker.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult Create(string title, string author, string publicationDate)
        {
            if (title != null)
                //if (Request.Query.Count > 0)
                {
                try
                {
                    ViewBag.Success = false;
                    CreateBook(title, author, publicationDate);
                    ViewBag.Success = true;
                    ViewBag.Message = "Successfully added book";
                }
                catch
                {
                    ViewBag.Success = true;
                    ViewBag.Message = "Something went wrong";
                }
            }
            ViewBag.Authors = AuthorController.GetAuthors();
            return View();
        }
        public IActionResult List(string filter)
        {
            try
            {
                if(filter == "list")
                {
                    ViewBag.Books = GetBooks();
                }
                else if (filter == "overdue")
                {
                    ViewBag.Books = GetOverdueBooks();
                }
                else
                {
                    ViewBag.Books = GetBooks();
                }

            }
            catch
            {

            }
            return View();
        }
        public IActionResult Details(string id, string action)
        {
            try
            {
                ViewBag.Book = GetBookByID(id);
            }
            catch
            {

            }
            return View();
        }

        public IActionResult Extend(string id)
        {
            ExtendDueDateForBorrowByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        public IActionResult Return(string id)
        {
            ReturnBookByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        public IActionResult Delete(string id)
        {
            DeleteBookByID(id);
            return RedirectToAction("List");
        }
        public IActionResult Borrow(string id)
        {
            CreateBorrow(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }

        public void CreateBook(string title, string authorId, string publicationDate)

        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Add(new Book()
                {
                    AuthorID = int.Parse(authorId),
                    Title = title,
                    PublicationDate = DateTime.Parse(publicationDate.Trim())
                });
                context.SaveChanges();
            }
        }
        public void ExtendDueDateForBorrowByID(string bookId)
        {
            BorrowController.ExtendDueDateForBorrowByID(bookId);
        }
        public void ReturnBookByID(string bookId)
        {
            BorrowController.ReturnBorrowByID(bookId);
        }
        public void DeleteBookByID(string bookId)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Remove(GetBookByID(bookId));
                context.SaveChanges();
            }
        }
        public void CreateBorrow(string bookId)
        {
            BorrowController.CreateBorrow(bookId);
        }

        public Book GetBookByID(string id)
        {
            Book specificBook;
            using (LibraryContext context = new LibraryContext())
            {
                specificBook = context.Books.Where(x => x.ID == int.Parse(id)).Include(x => x.Author).Include(x => x.Borrows).SingleOrDefault();
            }
            return specificBook;
        }
        public List<Book> GetBooks()
        {
            List<Book> booksList;
            using (LibraryContext context = new LibraryContext())
            {
                booksList = context.Books.Include(x => x.Author).Include(x => x.Borrows).ToList();

            }
            return booksList;
        }
        public List<Book> GetOverdueBooks()
        {
            List<Book> overDue;
            using (LibraryContext context = new LibraryContext())
            {
                List<Book> booksList = context.Borrows.Include(x => x.Book).Where(y => y.DueDate < DateTime.Now && y.ReturnedDate == null).Select(borrow => borrow.Book).ToList();

                overDue = context.Books.Include(x => x.Author).Include(x => x.Borrows).Where(x => booksList.Contains(x)).ToList();
            }
            return overDue;
        }
    }
}