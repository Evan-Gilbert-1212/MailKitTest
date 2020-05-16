using System.Threading.Tasks;
using MailKitTest.Models;
using MailKitTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;

namespace MailKitTest.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmailController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public EmailController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> SendEmail(IncomingEmailData emailToSend)
    {
      var newEmail = new Email()
      {
        Sender = "Evan Gilbert",
        EmailAddressFrom = "Evan.Gilbert1212@gmail.com",
        Recipient = emailToSend.Recipient,
        EmailAddressTo = emailToSend.EmailAddressTo,
        EmailSubject = emailToSend.EmailSubject,
        EmailBody = emailToSend.EmailBody
      };

      _context.Emails.Add(newEmail);
      await _context.SaveChangesAsync();

      //send email
      var message = new MimeMessage();

      message.From.Add(new MailboxAddress(newEmail.Sender, newEmail.EmailAddressFrom));
      message.To.Add(new MailboxAddress(newEmail.Recipient, newEmail.EmailAddressTo));

      message.Subject = newEmail.EmailSubject;

      message.Body = new TextPart("plain")
      {
        Text = @newEmail.EmailBody
      };

      using (var client = new SmtpClient())
      {
        client.Connect("smtp.gmail.com", 465, true);

        //Only if SMTP server requires authentication
        //need to authenticate user via OAuth 2.0 if using gmail for secure authentication
        client.Authenticate(newEmail.EmailAddressFrom, "password");

        client.Send(message);
        client.Disconnect(true);
      }

      return Ok();
    }
  }
}