using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScienceNewsBlog.Models;
using ScienceNewsBlog.Services;

namespace ScienceNewsBlog.Controllers
{
    public class ContactController : Controller
    {
        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        public ContactController(EmailAddress _fromAddress,
            IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Message from: {model.Name}<br>" +
                              $"Email: {model.Email}<br>" +
                              $" Message: {model.Message}<br>",
                    Subject = "Contact Form - " + model.Name
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("ThankYou");
            }
            else
            {
                return Index();
            }
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}