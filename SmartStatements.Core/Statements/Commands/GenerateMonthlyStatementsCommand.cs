using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.Statements.Commands
{
    public record GenerateMonthlyStatementsCommand(DateOnly Month) : IRequest;
  
}
