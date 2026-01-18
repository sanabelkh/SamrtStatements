using MediatR;
using SmartStatements.Core.Entities;
using SmartStatements.Core.IRepositories;
using SmartStatements.Core.IService;

using SmartStatements.Core.Statements.Commands;

namespace MonthlyStatements.Core.Features.Statements.Commands;

public class GenerateStatementCommandHandler : IRequestHandler<GenerateStatementCommand>
{
    private readonly IStatementRepository _repository;
    private readonly IEmailService _emailService;

    public GenerateStatementCommandHandler(
        IStatementRepository repository,
        IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task Handle(GenerateStatementCommand request, CancellationToken cancellationToken)
    {
        var statement = new Statement
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            Year = request.Year,
            Month = request.Month,
            TotalDebit = request.TotalDebit,
            GeneratedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(statement);
        await _emailService.SendStatementAsync(request.Email, statement);
    }
}
