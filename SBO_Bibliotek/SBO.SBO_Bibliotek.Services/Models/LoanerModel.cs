using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Models
{
    public class LoanerModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string LoanerEmail { get; set; }
        public string LoanerFirstname { get; set; }
        public string LoanerLastname { get; set; }
        public int LoanerPhone { get; set; }
        public string LoanerBook { get; set; }
    }
}
