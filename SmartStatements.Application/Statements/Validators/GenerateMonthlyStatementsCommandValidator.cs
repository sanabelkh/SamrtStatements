using FluentValidation;
using SmartStatements.Core.Statements.Commands;

public class GenerateMonthlyStatementsCommandValidator
    : AbstractValidator<GenerateMonthlyStatementsCommand>
{
    public GenerateMonthlyStatementsCommandValidator()
    {
        RuleFor(x => x.Month)
            .NotEmpty().WithMessage(" Empty Failed !");
            
    }
}
