using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Domain.Entities
{
    public class Loaner
    {
        public int LoanerId { get; set; }
        public string ISBN { get; set; }
        public string LoanerEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LoanerPhone { get; set; }
        public string LoanerBook { get; set; }
    }
}
