using System;
using System.Collections.Generic;

namespace LibraryDueDateTracker.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public List<Exception> ValidationExceptions { get; set; }


        public ValidationException() : base("Something went wrong. See below")
        {
            ValidationExceptions = new List<Exception>();
        }

        public ValidationException(string message) : base("Something went wrong. See below")
        {
            ValidationExceptions = new List<Exception>()
            {
                new Exception(message)
            };
        }
    }
}
