using System.Threading.Tasks;

namespace BlogSystem.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
