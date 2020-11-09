using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using LibraryDueDateTracker.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDueDateTracker.Controllers
{
    public class BorrowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static void CreateBorrow(string bookID)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Borrows.Add(new Borrow()
                {
                    BookID = int.Parse(bookID),
                    CheckedOutDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14)
                });
                context.SaveChanges();
            }
        }

        public static void ReturnBorrowByID(string bookID)
        {
            using (LibraryContext context = new LibraryContext())
            {
                Borrow returned = context.Borrows.Where(x => x.BookID == int.Parse(bookID)).SingleOrDefault();

                returned.ReturnedDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static void ExtendDueDateForBorrowByID(string bookID)
        {
            ValidationException exception = new ValidationException();
            using (LibraryContext context = new LibraryContext())
            {
                Borrow extend = context.Borrows.Where(x => x.BookID == int.Parse(bookID)).SingleOrDefault();

                if(extend.ExtensionCount >= 3)
                {
                    exception.ValidationExceptions.Add(new Exception("Can't extend more than 3 times"));
                }
                else if (extend.DueDate < DateTime.Now)
                {
                    exception.ValidationExceptions.Add(new Exception("Overdue books cannot be extended"));
                }
                else if (extend.ReturnedDate != null)
                {
                    exception.ValidationExceptions.Add(new Exception("Returned books cannot be extended"));
                }
                else
                {
                    extend.ExtensionCount++;
                    extend.DueDate = extend.DueDate.AddDays(7);
                
                    context.SaveChanges();
                }
            }
        }
    }
}
