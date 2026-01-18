using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmartStatements.Core.Statements.Commands
{

    public record GenerateStatementCommand(
    Guid CustomerId,
    string Email,
    int Year,
    DateOnly Month,
    decimal OpeningBalance ,
    decimal TotalCredit ,
    decimal TotalDebit ,
    decimal ClosingBalance 
) : IRequest;
}
