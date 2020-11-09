using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using LibraryDueDateTracker.Models.Exceptions;
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
            if (Request.Query.Count > 0)
            {
                try
                {
                    CreateBook(title, author, publicationDate);
                    ViewBag.Message = "Successfully added book";
                }
                catch (ValidationException e)
                {
                    ViewBag.Message = "something went wrong";
                    ViewBag.Exception = e;
                    ViewBag.Error = true;
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
        public IActionResult Details(string id, string button)
        {
            var detailsPage = RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
            var listPage = RedirectToAction("List", new Dictionary<string, string>() { { "id", id } });

            try 
            {
                ViewBag.Book = GetBookByID(id);
                switch (button)
                {
                    case "borrow":
                        BorrowController.CreateBorrow(id);
                        return detailsPage;
                    case "extend":
                        BorrowController.ExtendDueDateForBorrowByID(id);
                        return detailsPage;
                    case "delete":
                        DeleteBookByID(id);
                        return listPage;
                    case "return":
                        BorrowController.ReturnBorrowByID(id);
                        return detailsPage;
                    default:
                        return View();
                }
            }
            catch (ValidationException e)
            {
                ViewBag.Message = e;
            }
            return View();
        }

        public void CreateBook(string title, string authorId, string publicationDate)
        {
            int parsedAuthorID = 0;
            ValidationException exception = new ValidationException();

            title = !string.IsNullOrWhiteSpace(title) ? title.Trim() : null;
            authorId = !string.IsNullOrWhiteSpace(authorId) ? authorId.Trim() : null;
            publicationDate = !string.IsNullOrWhiteSpace(publicationDate) ? publicationDate.Trim() : null;


            using (LibraryContext context = new LibraryContext())
            {
                if(string.IsNullOrWhiteSpace(title))
                {
                    exception.ValidationExceptions.Add(new Exception("title cannot be empty"));
                }
                else if (title.Length > 100)
                {
                    exception.ValidationExceptions.Add(new Exception("Title is too long, less than 100 characters please."));
                }

                if(string.IsNullOrWhiteSpace(authorId))
                {
                    exception.ValidationExceptions.Add(new Exception("Author Cannot be Empty"));
                }
                else if(!int.TryParse(authorId, out parsedAuthorID))
                {
                    exception.ValidationExceptions.Add(new Exception("Author ID is not in a vlid format"));
                }
                else if(!context.Authors.Any(x => x.ID == parsedAuthorID))
                {
                    exception.ValidationExceptions.Add(new Exception("Author does not exist"));
                }
                else if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(authorId))
                {
                    List<int> authorsIDList = context.Books.Where(x => x.Title.ToLower() == title.ToLower()).Select(x => x.AuthorID).ToList();

                    if (authorsIDList.Any() && authorsIDList.Contains(parsedAuthorID))
                    {
                        exception.ValidationExceptions.Add(new Exception("This author already has this book"));
                    }
                }

                if(string.IsNullOrWhiteSpace(publicationDate))
                {
                    exception.ValidationExceptions.Add(new Exception("Date cannot be empty"));
                }
                else if(DateTime.Parse(publicationDate) > DateTime.Now)
                {
                    exception.ValidationExceptions.Add(new Exception("Publication date cannot be in the future"));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                context.Books.Add(new Book()
                {
                    AuthorID = int.Parse(authorId),
                    Title = title,
                    PublicationDate = DateTime.Parse(publicationDate.Trim())
                });
                context.SaveChanges();
            }
        }
        public void DeleteBookByID(string bookId)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Remove(GetBookByID(bookId));
                context.SaveChanges();
            }
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