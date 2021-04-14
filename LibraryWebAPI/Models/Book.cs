using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int PagesCount { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
