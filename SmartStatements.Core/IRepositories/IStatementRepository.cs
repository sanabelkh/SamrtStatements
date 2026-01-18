using SmartStatements.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.IRepositories
{
    public interface IStatementRepository
    {
        Task<Statement> GenerateAsync(Guid customerId, DateOnly month);

        Task AddAsync(Statement statement);
        Task<Statement?> GetAsync(Guid customerId, int year, DateOnly month);


    }
}
