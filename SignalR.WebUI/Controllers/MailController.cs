using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.MailDtos;

namespace SignalR.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto cmdto)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Z&S Restoran Rezervasyon", "fatmazehraseren@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", cmdto.ReceiverMail);
            message.To.Add(to);

            var builder = new BodyBuilder();
            builder.TextBody = cmdto.Body;
            message.Body = builder.ToMessageBody();

            message.Subject = cmdto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("fatmazehraseren@gmail.com", "nmdu ufbp ktqi retd");

            client.Send(message);
            client.Disconnect(true);

            return RedirectToAction("Index", "Statistic");
        }
    }
}
