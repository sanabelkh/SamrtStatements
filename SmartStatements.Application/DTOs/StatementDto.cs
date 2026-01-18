using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.DTOs
{
    public class StatementDto
    {
        public Guid CustomerId { get; set; }
        public int Year { get; set; }
        public DateOnly Month { get; set; }
        public decimal Amount { get; set; }


    }
}
