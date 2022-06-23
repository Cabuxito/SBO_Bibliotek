using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Domain.Entities
{
    public class Books
    {
        public string ISBN { get; set; }
        public string Book_Title { get; set; }
        public string Publication  { get; set; }
        public string Publisher { get; set; }
        public string Author_Name { get; set; }
        public string Genre_Name { get; set; }

    }
}
