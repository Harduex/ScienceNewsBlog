using ScienceNewsBlog.Models;

namespace ScienceNewsBlog.Services
{
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}
