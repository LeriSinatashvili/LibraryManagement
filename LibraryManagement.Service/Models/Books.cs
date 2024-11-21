using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    internal class Books
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime BookPublicationDate { get; set; }
        public string BookAutor { get; set; }
        public int BookNumberOfPages { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }

    }
}
