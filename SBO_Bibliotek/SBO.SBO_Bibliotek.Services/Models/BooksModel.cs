using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Models
{
    public class BooksModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Publication { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
