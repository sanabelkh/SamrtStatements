using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.Entities
{
    public class Statement
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Year { get; set; }
        public DateOnly Month { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal ClosingBalance { get; set; }
        public DateTime GeneratedAt { get; set; }


    }
}
