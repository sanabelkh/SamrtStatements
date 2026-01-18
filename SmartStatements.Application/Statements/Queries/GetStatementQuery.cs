using MediatR;
using SmartStatements.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.Statements.Queries
{
    public record GetStatementQuery(
     Guid CustomerId,
     int Year,
     DateOnly Month
 ) : IRequest<Statement?>;
}
