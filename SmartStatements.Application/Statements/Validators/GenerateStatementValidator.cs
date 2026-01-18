using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SmartStatements.Core.Statements.Commands;

namespace SmartStatements.Core.Statements.Validators
{
    public class GenerateStatementValidator : AbstractValidator<GenerateStatementCommand>
    {
        public GenerateStatementValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Customer email is not valid"); 


            RuleFor(x => x.TotalCredit).GreaterThan(0);
            RuleFor(x => x.TotalDebit).GreaterThan(0);
            RuleFor(x => x.OpeningBalance).GreaterThan(0);
            RuleFor(x => x.ClosingBalance).GreaterThan(0);

            RuleFor(x => x.Month)
                .NotEmpty()
                .WithMessage("Month must be between 1 and 12 And Not Empty");


            RuleFor(x => x.Year)
                .GreaterThan(2000)
                .WithMessage("Year is invalid");
        }



    }
}
