using MediatR;
using SmartStatements.Core.Entities;
using SmartStatements.Core.IRepositories;
using SmartStatements.Core.Statements.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SmartStatements.Core.Statements.Handlers
{
    public class GetStatementQueryHandler : IRequestHandler<GetStatementQuery, Statement?>
    {

        private readonly IStatementRepository _repository;

        public GetStatementQueryHandler(IStatementRepository repository)
        {
            _repository = repository;
        }

        public Task<Statement?> Handle(GetStatementQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAsync(request.CustomerId, request.Year, request.Month);
        }

    }
}
