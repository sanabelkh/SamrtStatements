using SmartStatements.Core.Entities;
using SmartStatements.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Infra.Persistence
{
    public  class InMemoryDb : ICustomerRepository
    {
        public static  List<Statement> Statements { get; } = [
        new Statement
        {
            CustomerId = new Guid(),
            Month =new DateOnly(2024, 1, 18) ,
            Year = 2025,
            OpeningBalance = 1000,
            TotalCredit = 500,
            TotalDebit = 300,
            ClosingBalance = 1200
        },
        new Statement
        {
            CustomerId = new Guid(),
            Month = new DateOnly(2024, 1, 18),
            Year = 2025,
            OpeningBalance = 2000,
            TotalCredit = 1000,
            TotalDebit = 400,
            ClosingBalance = 2600
        }
    ];

        public  Task<List<Customer>> GetAllAsync()
         => Task.FromResult(_customers);


        private static readonly List<Customer> _customers =
    [
        new Customer { Id = new Guid(), Name = "Ahmad", Email = "ahmad@test.com" },
        new Customer { Id = new Guid(), Name = "Sara", Email = "sara@test.com" }
    ];
    }
}
