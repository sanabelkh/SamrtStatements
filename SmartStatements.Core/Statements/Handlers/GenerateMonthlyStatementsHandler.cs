    using MediatR;
    using SmartStatements.Core.Entities;
    using SmartStatements.Core.IRepositories;
    using SmartStatements.Core.IService;
    using SmartStatements.Core.Statements.Commands;

    public class GenerateMonthlyStatementsHandler
        : IRequestHandler<GenerateMonthlyStatementsCommand>
    {
        private readonly IStatementRepository _repository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IEmailService _emailService;

        public GenerateMonthlyStatementsHandler(
            IStatementRepository repository,
             ICustomerRepository customerRepository,
            IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _repository = repository;
            _emailService = emailService;
        }

        public async Task Handle(
            GenerateMonthlyStatementsCommand request,
            CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            foreach (var customer in customers)
            {
                var statement = await _repository.GenerateAsync(
                    customer.Id,
                    request.Month);

                var body = $@"
    Hello {customer.Name},

    Your monthly statement for {request.Month:MMMM yyyy}

    Opening Balance: {statement.OpeningBalance}
    Total Credit: {statement.TotalCredit}
    Total Debit: {statement.TotalDebit}
    Closing Balance: {statement.ClosingBalance}

    Thank you.
    ";

                await _emailService.SendAsync(
                    customer.Email,
                    $"Monthly Statement - {request.Month:MMMM yyyy}",
                    body);
            }
        }
    }
