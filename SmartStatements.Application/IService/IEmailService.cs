using SmartStatements.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStatements.Core.IService
{
    public interface IEmailService
    {
            Task SendStatementAsync(string email, Statement statement);
        public Task SendAsync(string to, string subject, string body);


    }
}
