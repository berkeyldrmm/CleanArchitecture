using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string recieverEmail, string receiverNameSurname, string subject, string title, string body);
        Task SendRegistrationEmail(string recieverEmail, string receiverNameSurname);
        Task SendConfirmationEmail(string recieverEmail, string receiverNameSurname, string userId, string token);
    }
}
