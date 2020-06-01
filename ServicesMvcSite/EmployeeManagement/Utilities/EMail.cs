using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmployeeManagement.Utilities
{
    public class EMail
    {

        private readonly IConfiguration configuration;
        private readonly IDataProtector dataProtector;
        private readonly int port;
        private readonly string account;
        private readonly string host;
        private readonly string password;

        public EMail(IConfiguration configuration)
        {
            this.configuration = configuration;
            try
            {
                this.account = configuration.GetValue<string>("AccountMail:Account");
                this.port = configuration.GetValue<int>("AccountMail:Port");
                this.host = configuration.GetValue<string>("AccountMail:Host");
                this.password = configuration.GetValue<string>("AccountMail:Password");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Send(string to, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage(this.account, to, subject, body);

            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(this.host);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = this.host;
            smtpClient.Port = this.port;
            smtpClient.Credentials = new System.Net.NetworkCredential(this.account, this.password);

            smtpClient.Send(mailMessage);

            smtpClient.Dispose();
        }
    }
}
