using Microsoft.Extensions.Options;
using SmartStatements.Core.Entities;
using SmartStatements.Core.IService;
using SmartStatements.Infra.Settings;
using System.Net;
using System.Net.Mail;

namespace SmartStatements.Infra.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public SmtpEmailService(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;
        }


        //Here Suggest FakeOne
        public async Task SendAsync(string to, string subject, string body)
        {

            Console.WriteLine("====================================");
            Console.WriteLine("FAKE EMAIL SENT");
            Console.WriteLine($"To      : {to}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine("Body:");
            Console.WriteLine(body);
            Console.WriteLine("====================================");

             await Task.CompletedTask;
           
        }

       

         //I Create Here Real Stmp Connection 
          public async Task SendStatementAsync(string email, Statement statement)
        { 


            var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.Username,
                    _settings.Password),
                EnableSsl = _settings.EnableSsl
            };
           var message = 
             new MailMessage("your_email@gmail.com",
             email,
            "Monthly Statement",
            $"CustomerID : {statement.CustomerId}" +
            $" , Total Criedt: {statement.TotalCredit}" +
            $" for {statement.Month}/{statement.Year}");
            await client.SendMailAsync(message); }
    
    }
}
