using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
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
            using (LibraryContext context = new LibraryContext())
            {
                Borrow extend = context.Borrows.Where(x => x.BookID == int.Parse(bookID)).SingleOrDefault();

                extend.DueDate = extend.DueDate.AddDays(7);
                context.SaveChanges();
            }
        }
    }
}
