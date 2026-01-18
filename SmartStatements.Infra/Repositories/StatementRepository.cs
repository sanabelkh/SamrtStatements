using SmartStatements.Core.Entities;
using SmartStatements.Core.IRepositories;
using SmartStatements.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Infra.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        public Task AddAsync(Statement statement)
        {
            InMemoryDb.Statements.Add(statement);
            return Task.CompletedTask;
        }

        public Task<Statement> GenerateAsync(Guid customerId, DateOnly month)
        {
            var statement = InMemoryDb.Statements
                       .FirstOrDefault(s =>
                           s.CustomerId == customerId &&
                           s.Month == month &&
                           s.Year == month.Year);

            if (statement == null)
                throw new Exception("Statement not found");

            return Task.FromResult(statement);
        }

        public Task<Statement?> GetAsync(Guid customerId, int year, DateOnly month)
        {
            var statement = InMemoryDb.Statements.FirstOrDefault(s =>
                s.CustomerId == customerId &&
                s.Year == year &&
                s.Month == month);

            return Task.FromResult(statement);
        }


    }
}
