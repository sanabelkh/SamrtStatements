using SmartStatements.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.IRepositories
{
    public interface ICustomerRepository
    {

        Task<List<Customer>> GetAllAsync();



    }
}
